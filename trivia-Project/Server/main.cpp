#pragma comment (lib, "ws2_32.lib")
#include <iostream>
#include "Server.h"

int main()
{
	std::cout << "Server ON" << std::endl;
	Server::getInstance().run();//run the server
	std::cout << "Server OFF" << std::endl;
	return 0;
}
