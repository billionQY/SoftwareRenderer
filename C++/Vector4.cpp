#include "Vector4.h"

Vector4& Vector4::operator =(const Vector4 &rhs)
{
	x = rhs.x;
	y = rhs.y;
	z = rhs.z;
	return *this;
}

void Vector4::Zero()
{
	x = 0;
	y = 0;
	z = 0;
	w = 0;
}
