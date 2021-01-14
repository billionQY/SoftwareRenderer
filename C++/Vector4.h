#pragma once

class Vector4
{
public:
	Vector4() : x(0), y(0), z(0), w(0) { }
	Vector4(float _x, float _y, float _z, float _w) : x(_x), y(_y), z(_z), w(_w) { }

public:
	Vector4& operator =(const Vector4 &rhs);

public:
	void Zero();

public:
	float x;
	float y;
	float z;
	float w;
};

