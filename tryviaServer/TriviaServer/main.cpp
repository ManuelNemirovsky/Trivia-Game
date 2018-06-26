#pragma comment (lib, "ws2_32.lib")
#include "TriviaServer.h"
#include <iostream>
#include <sstream>

#include "Helper.h"

void main()
{
	try
	{
		TRACE("Starting...");
		srand(time(NULL));

		TriviaServer md_server;
		md_server.serve();
	}
	catch (const std::exception& e)
	{
		std::cout << "Exception was catch in function: " << e.what() << std::endl;
	}
	catch (...)
	{
		std::cout << "Unknown exception in main !" << std::endl;
	}
}
