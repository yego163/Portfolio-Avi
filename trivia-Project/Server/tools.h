#pragma once
#include <iostream>
#include <vector>
#include <map>
#include "LoggedUser.h"
#include "IDatabase.h"
#include "ResponseStructs.h"
#include "Room.h"

std::vector<std::string> splitString(std::string s, std::string separate);

bool roomInVector(std::vector<RoomData> rooms, RoomData r);