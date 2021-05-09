#pragma once
#include<ctime>
#include<vector>

struct RequestInfo
{
public:
	int id; 
	time_t receivalTime;
	std::vector<unsigned char> buffer;
};