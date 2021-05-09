#include "Buffer.h"


Buffer stringToBuffer(std::string data)
{
	return Buffer(data.begin(), data.end());//string to buffer
}

std::string BufferToString(Buffer data)
{
	std::string s = std::string(data.begin(), data.end());
	return s;
}
