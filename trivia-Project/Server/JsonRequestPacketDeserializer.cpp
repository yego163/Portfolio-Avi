#include "JsonRequestPacketDeserializer.h"

LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(Buffer buff)
{
	std::string data = BufferToString(buff);
	json j = json::parse(data);
	LoginRequest lr = { j["username"].get<std::string>(), //get the username
						j["password"].get<std::string>()};//get the password
	return lr;
}

SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(Buffer buff)
{
	std::string data = BufferToString(buff);
	json j = json::parse(data);

	SignupRequest sg = { j["username"].get<std::string>(), //get the username
						j["password"].get<std::string>(),//get the password
						j["email"].get<std::string>()};//get the email
	return sg;
}

GetPlayersInRoomRequest JsonRequestPacketDeserializer::deserializeGetPlayersRequest(Buffer buff)
{
	std::string data = BufferToString(buff);
	json j = json::parse(data);

	GetPlayersInRoomRequest gp = {j["roomId "].get<unsigned int>()};
	return gp;
}

JoinRoomRequest JsonRequestPacketDeserializer::deserializeJoinRoomRequest(Buffer buff)
{
	std::string data = BufferToString(buff);
	json j = json::parse(data);

	JoinRoomRequest jr { j["roomId"].get<unsigned int>()};
	return jr;
}

CreateRoomRequest JsonRequestPacketDeserializer::deserializeCreateRoomRequest(Buffer buff)
{
	std::string data = BufferToString(buff);
	json j = json::parse(data);

	CreateRoomRequest cr = { j["roomName"].get<std::string>(), //get the roomName
						j["maxUsers"].get<int>(),//get the maxUsers
						j["questionCount"].get<int>(),//get the question Count
						j["answerTimeout"].get<int>()};//get the answerTimeout
	return cr;
}

SubmitAnswerRequest JsonRequestPacketDeserializer::deserializeSubmitAnswer(Buffer buff)
{
	std::string data = BufferToString(buff);
	json j = json::parse(data);
	SubmitAnswerRequest ret = { j["answerId"]};
	return ret;
}
