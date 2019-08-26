using System;

namespace Console1
{
	class Program
	{
		static void Main(string[] args)
		{
			string command;
			var isLoggedIn = false;
			var correctPassword = "7427466391";
            string password1 = "";
			int level = 0;
			var username = "user";
			var level2password = "90193076543";
			var level3password = "16218187897";
            int passwordtries = 3;
            int passwordTries = 0;
            bool outoftries = false;
			bool quitNow = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

			Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Nick's Console"));

			while (quitNow == false)
			{
				Console.Write("Console> ");
				command = Console.ReadLine();
				switch (command)
				{
					case "help":
						if (level < 1)
						{ 
							Console.WriteLine();
							Console.WriteLine("exit - exits the console");
							Console.WriteLine("help - display this list");
                            Console.WriteLine("hint - a hint towards the next password");
							Console.WriteLine("level - shows what level you are currently at");
							Console.WriteLine("login - login into the mainframe");
							Console.WriteLine();
						}
						else if (level >= 1)
						{
							Console.WriteLine();
							Console.WriteLine("exit - exits the console");
							Console.WriteLine("help - display this list");
                            Console.WriteLine("hint - a hint towards the next password");
                            Console.WriteLine("level  - shows what level you are currently at");
							Console.WriteLine("levelup - allows you to attempt to level up, password required");
							Console.WriteLine("logout - logs out of mainframe");
							Console.WriteLine();
						}
						break;

					case "version":
						Console.WriteLine("This is version 2.1");
						break;

					case "levelup":
						Console.WriteLine();

						Console.Write("Please enter your level up password: ");
						string password = ReadPassword();
						if (password == level2password)
						{
							if (level == 1)
							{
								level = 2;
								Console.WriteLine("Correct Password Entered. Your level is now " + level + ".");
							}
							else if (level > 1)
							{
								Console.WriteLine("You have already used this level up code. You are currently level " + level);
							}
							else if (level < 1)
							{
								Console.WriteLine("You do not have the required level to use this code. You are currently level " + level);
							}
						}
						else if (password == level3password)
						{
							if (level == 2)
							{
								level = 3;
								Console.WriteLine("Correct Password Entered. Your level is now " + level + ".");
							}
							else if (level > 2)
							{
								Console.WriteLine("You have already used this level up code. You are currently level " + level);
							}
							else if (level < 2)
							{
								Console.WriteLine("You do not have the required level to use this code. You are currently level " + level);
							}
						}
						else
						{
							Console.WriteLine("The password entered is invalid. Please try again.");
						}
						Console.WriteLine();
						break;

					case "exit":
						quitNow = true;
						break;

					case "level":
						Console.WriteLine();

						Console.WriteLine("Your current level is " + level + ".");
						Console.WriteLine();

						break;

					case "login":
						Console.WriteLine();

						if (isLoggedIn == true)
						{
							Console.WriteLine("You are already logged in.");
						}
						else
						{
							Console.Write("Please enter your username: ");
							string userEntry = Console.ReadLine();
							if (userEntry == username)
							{
                                while(password1 != correctPassword && !outoftries)
                                {
                                    if (passwordtries > 0)
                                    {
                                        Console.Write("Please enter your password: ");
                                        password1 = ReadPassword();
                                        passwordtries--;
                                        passwordTries++;
                                        Console.WriteLine();
                                        Console.WriteLine("Incorrect Password. You have " + passwordtries + " password guesses left");
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        outoftries = true;
                                    }
                                }

								if (outoftries)
								{
                                    outoftries = false;
                                    passwordtries = 3;
                                    Console.WriteLine("You have entered the password incorrectly " + passwordTries + " times. Wait 10 seconds before trying again.");
                                    System.Threading.Thread.Sleep(10000);
                                }
                                else
								{
                                    isLoggedIn = true;
                                    level = 1;
                                    Console.WriteLine("Correct Password, you have logged in. Your level is now " + level + ".");
								}
							}
							else
							{
								Console.WriteLine("The user " + userEntry + " does not exist.");
							}

						}
						Console.WriteLine();
                        
						break;


					case "files":
						Console.WriteLine();

						if (level == 0)
						{
							Console.WriteLine("You are not permitted to view files.");
						}
						else if (level == 1)
						{
                            Console.WriteLine("Folders:  home   user");
                            Console.WriteLine("Files: ");
                            Console.WriteLine();
                            Console.Write("Files> ");
                            string fileinput = Console.ReadLine();
                            if (fileinput == "cd user")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Folders: ");
                                Console.WriteLine("Files: levelpassword.txt");
                                Console.WriteLine();
                                Console.Write("Files> ");
                                string fileinput2 = Console.ReadLine();
                                if (fileinput2 == "levelpassword.txt")
                                {

                                    Console.WriteLine("levelpassword.txt");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("AES");
                                    Console.WriteLine("The key is the filename itself");
                                    Console.WriteLine("LZm5N8NCe6Esi0YLkvaKNQ==");
                                    Console.WriteLine("Good luck.");
                                    Console.WriteLine();

                                }
                            }
						}

						Console.WriteLine();
						break;

                    case "hint":
                        Console.WriteLine();

                        if (level == 0)
                        {
                            Console.WriteLine("Try the first 10 digit prime found in consecutive digits of e. Good luck.");
                        }
                        
                        Console.WriteLine();
                        break;

                    case "test":
                        Console.WriteLine("");
                        Console.WriteLine("This works, doesnt it?");
                        Console.WriteLine("");
                        break;

					case "logout":
						Console.WriteLine();

						if (level >= 1)
						{
							isLoggedIn = false;
							level = 0;
						}
						else
						{
							Console.WriteLine("You are not logged in.");
						}
						Console.WriteLine();

						break;

					default:
						Console.WriteLine("Unknown Command: " + command);
						break;
				}
			}

		}

		public static string ReadPassword()
		{
			string password = "";
			ConsoleKeyInfo info = Console.ReadKey(true);
			while (info.Key != ConsoleKey.Enter)
			{
				if (info.Key != ConsoleKey.Backspace)
				{
					Console.Write("*");
					password += info.KeyChar;
				}
				else if (info.Key == ConsoleKey.Backspace)
				{
					if (!string.IsNullOrEmpty(password))
					{
						password = password.Substring(0, password.Length - 1);
						int pos = Console.CursorLeft;
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
						Console.Write(" ");
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
					}
				}
				info = Console.ReadKey(true);
			}
			Console.WriteLine();
			return password;
		}
	}
}