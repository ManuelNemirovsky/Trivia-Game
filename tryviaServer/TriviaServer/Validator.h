#pragma once

#include <string>
using namespace std;

class Validator
{
public:
	static bool isPasswordValid(string password)
	{
		// must contain at least 4 characters
		// not contain backspace
		// must contain at least 1 digit
		// must contain at least 1 lowercase letter
		// must contain at least 1 uppercase letter

		int size = password.size();
		if (size < 4)
			return false;

		if (password.find(' ') != string::npos)
			return false;

		bool isDigit = false;
		bool isLower = false;
		bool isUpper = false;
		
		for (int i = 0; i < size; i++)
		{
			if (password[i] >= 'A' && password[i] <= 'Z')
				isUpper = true;
			else if (password[i] >= 'a' && password[i] <= 'z')
				isLower = true;
			else if (password[i] >= '0' && password[i] <= '9')
				isDigit = true;
		}

		return isUpper && isLower && isDigit;
	}


	static bool isUsernameValid(string username)
	{
		// user name must start with letter
		// cannot contain backspace
		// cannot be empty

		if (username == "")
			return false;

		char firstLetter = username[0];

		if (firstLetter < 'A' || firstLetter > 'z')
			return false;

		if (username.find(' ') != string::npos)
			return false;

		return true;
	}
};