#pragma once
#include <vector>
#include <iostream>

typedef std::vector<unsigned char> Buffer;

Buffer stringToBuffer(std::string data);

std::string BufferToString(Buffer data);