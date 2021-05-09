#include "LoginRequestHandler.h"
#include "messagesCodes.h"

LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory* factory, IDatabase* db)
{
	m_db = db;
	m_handlerFactory = factory;
}

bool LoginRequestHandler::isRequestRelevant(RequestInfo RequestInfo)
{
	return RequestInfo.id == LOGIN_ID || RequestInfo.id == SIGNUP_ID;
}

RequestResult LoginRequestHandler::handleRequest(RequestInfo RequestInfo)
{
	RequestResult reqRes;
	JsonResponsePacketSerializer ResponsePacket;
	if (isRequestRelevant(RequestInfo))
	{
		switch (RequestInfo.id)
		{
		case LOGIN_ID:
		{
			reqRes = login(RequestInfo);
			break;
		}
		case SIGNUP_ID:
		{
			reqRes = signup(RequestInfo);
			break;
		}
		default:
			break;
		}
	}
	else
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = "The Request is not Relevant";
		reqRes.newHandler = m_handlerFactory->createLoginRequestHandler();
		reqRes.response = ResponsePacket.serializeErrorResponse(erorr);
	}
	return reqRes;
}

RequestResult LoginRequestHandler::login(RequestInfo RequestInfo)
{
	RequestResult reqRes;
	JsonResponsePacketSerializer ResponsePacket;
	LoginResponse loginResponse = LoginResponse();
	JsonRequestPacketDeserializer jsonPacket;
	LoginRequest lr = jsonPacket.deserializeLoginRequest(RequestInfo.buffer);
	try//try to login
	{
		m_handlerFactory->getLoginManager().login(lr.username, lr.password);
		loginResponse.status = OK;
		reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(lr.username);
		reqRes.response = ResponsePacket.serializeLoginResponse(loginResponse);
	}
	catch (const std::exception & e)//faield login - cant
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		loginResponse.status = ERR;//cant login
		reqRes.response = ResponsePacket.serializeErrorResponse(erorr);
		reqRes.newHandler = m_handlerFactory->createLoginRequestHandler();
	}
	return reqRes;
}

RequestResult LoginRequestHandler::signup(RequestInfo RequestInfo)
{
	RequestResult reqRes;
	JsonResponsePacketSerializer ResponsePacket;
	SignupResponse signupResponse = SignupResponse();
	JsonRequestPacketDeserializer jsonPacket;
	signupResponse.status = OK;
	reqRes.response = ResponsePacket.serializeSignUpResponse(signupResponse);
	SignupRequest sr = jsonPacket.deserializeSignupRequest(RequestInfo.buffer);
	reqRes.newHandler = m_handlerFactory->createMenuRequestHandler(sr.username);
	try
	{
		m_handlerFactory->getLoginManager().signup(sr.username, sr.password, sr.email);
	}
	catch (const std::invalid_argument& e)
	{
		ErrorResponse erorr = ErrorResponse();
		erorr.message = e.what();
		signupResponse.status = ERR;
		reqRes.response = ResponsePacket.serializeErrorResponse(erorr);
		delete reqRes.newHandler;
		reqRes.newHandler = m_handlerFactory->createLoginRequestHandler();
	}
	return reqRes;
}

