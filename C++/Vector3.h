#pragma once

class Vector3
{
public:
	Vector3() : x(0), y(0), z(0) { }
	Vector3(float _x, float _y, float _z) : x(_x), y(_y), z(_z) { }

public:
	float x;
	float y;
	float z;
};

