#include "tools.h"


std::vector<std::string> splitString(std::string s, std::string separate)
{
	std::vector<std::string> vec = std::vector<std::string>();
	size_t pos = 0;
	std::string token;
	while ((pos = s.find(separate)) != std::string::npos) {
		token = s.substr(0, pos);
		vec.push_back(token);
		s.erase(0, pos + separate.length());
	}
	if (s != "")
		vec.push_back(s);
	return vec;
}

bool roomInVector(std::vector<RoomData> rooms, RoomData r)
{
	for (size_t i = 0; i < rooms.size(); i++)
		if (rooms[i].getId() == r.getId())
			return true;
	return false;
}