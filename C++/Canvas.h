#pragma once

#include <string>
#include <vector>

#include "Vector4.h"

class Canvas
{
public:
	Canvas() { }

public:
	void SavaBmp(std::vector<Vector4> &frameBuffer, int width, int height, std::string file);
};

