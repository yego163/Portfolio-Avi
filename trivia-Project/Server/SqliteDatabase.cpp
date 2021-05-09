#include "SqliteDatabase.h"

//call back

int getNumbers(void* data, int argc, char** argv, char** azColName)
{
	std::list<int>* list = (std::list<int>*)data;
	int number = 0;
	for (int i = 0; i < argc; i++)
		number = atoi(argv[i]);
	list->push_back(number);
	return 0;
}

int getQuestions(void* data, int argc, char** argv, char** azColName)
{
	std::list<Question>* list = (std::list<Question>*)data;
	Question temp = Question("", std::vector<std::string>(), 0);
	for (int i = 0; i < argc; i++) {
		if (std::string(azColName[i]) == "Question")
			temp.m_question = argv[i];
		else if (std::string(azColName[i]) == "WrongAnswers")
			temp.m_possivleAnswers = splitString(std::string() + argv[i], ";");
		else if (std::string(azColName[i]) == "CorrectAnswer")
			temp.m_possivleAnswers.push_back(argv[i]);
		temp.num_correctAnswer = std::distance(temp.m_possivleAnswers.begin(), //get the index of the correct answer from the vector
			std::find(temp.m_possivleAnswers.begin(), temp.m_possivleAnswers.end(), argv[i]));
	}
	list->push_back(temp);
	return 0;
}

int getUsers(void* data, int argc, char** argv, char** azColName)
{
	std::list<SignupRequest>* list = (std::list<SignupRequest>*)data;
	SignupRequest temp = SignupRequest();
	for (int i = 0; i < argc; i++) {
		if (std::string(azColName[i]) == "USER_NAME")
			temp.username = argv[i];
		else if (std::string(azColName[i]) == "PASSWORD")
			temp.password = argv[i];
		else if (std::string(azColName[i]) == "EMAIL")
			temp.email = atoi(argv[i]);
	}
	list->push_back(temp);
	return 0;
}

//sqliteCommands types

bool SqliteDatabase::command(std::string command, int callback(void* data, int argc, char** argv, char** azColName), void* data)
{
	char** errMessage = nullptr;

	int res = sqlite3_exec(db, command.c_str(), callback, data, errMessage);//create persons
	if (res != SQLITE_OK) {//if it failed
		if (errMessage == nullptr)
			std::cout << "FAILD: " << command << std::endl;
		else
			std::cout << std::string(*errMessage) << std::endl;//print the err
		return false;
	}
	return true;
}

bool SqliteDatabase::command(std::string command)
{
	char** errMessage = nullptr;
	int res = sqlite3_exec(db, command.c_str(), nullptr, nullptr, errMessage);//create persons
	if (res != SQLITE_OK) {//if it failed
		if (errMessage == nullptr)
			std::cout << "FAILD: " << command << std::endl;
		else
			std::cout << std::string(*errMessage) << std::endl;//print the err
		return false;
	}
	return true;

}

//constructors
SqliteDatabase::SqliteDatabase()
{
	rng = std::default_random_engine(std::chrono::system_clock::now().time_since_epoch().count());//init the random
	std::string dbFileName = "TRIVIA.sqlite";
	int doesFileExist = _access(dbFileName.c_str(), 0);
	int res = sqlite3_open(dbFileName.c_str(), &db);
	if (res != SQLITE_OK) {//if it couldn't open the data base
		db = nullptr;
		std::cout << "Failed to open DB" << std::endl;
		throw "CANT CREATE DB";
	}
	if (doesFileExist == -1) {//if it open a new data base
		if (!createTables())
		{//if failed create
			sqlite3_close(db);
			db = nullptr;
			remove("TRIVIA.sqlite");//remove the empty file
			throw std::invalid_argument("CANT CREATE TABLES");
		}
		insertStartQuestions();
	}
}

SqliteDatabase::~SqliteDatabase()
{
	if (db != nullptr) {
		sqlite3_close(db);
		db = nullptr;
	}
}

bool SqliteDatabase::createTables()
{
	return !(!command(std::string()//users table 
		+ "CREATE TABLE IF NOT EXISTS Users "
		+ "(USER_NAME TEXT PRIMARY KEY NOT NULL," //USERNAME, can be use only once
		+ " PASSWORD TEXT NOT NULL," //Password
		+ "EMAIL TEXT NOT NULL);")//EMAIL
		|| !command(std::string()
			+ "CREATE TABLE IF NOT EXISTS Questions "
			+ "(IDX INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"//index of q
			+ "Question TEXT NOT NULL," //q
			+ " WrongAnswers TEXT NOT NULL," //all the wrong answers - separate by ;
			+ "CorrectAnswer TEXT NOT NULL);")//correct answer
		|| !command(std::string()
			+ "CREATE TABLE IF NOT EXISTS Statistics "
			+ "(GamesTotal INTEGER NOT NULL,"//total games the player played
			+ "QuestionsTotal INTEGER NOT NULL,"//total q the player answered
			+ "CorrectTotal INTEGER NOT NULL,"//total correct q the player answer
			+ "AVG_Time REAL NOT NULL,"//the avg time that took the player to answer the q
			+ "USER_NAME TEXT PRIMARY KEY NOT NULL,"//the name of the player
			+ "FOREIGN KEY(USER_NAME) REFERENCES Users(USER_NAME));")//bond the player to the user table
		);
}

//1.0.0V

bool SqliteDatabase::doesUserExist(std::string userName)
{
	std::list<SignupRequest> users = std::list<SignupRequest>();
	if (!command((std::string() + "SELECT * FROM Users WHERE USER_NAME = \"" + userName + "\";"), getUsers, (void*)&users))
		std::cout << "Err check if exist" << std::endl;
	return !users.empty();
}

bool SqliteDatabase::doesPasswordMatch(std::string userName, std::string password)
{
	std::list<SignupRequest> users = std::list<SignupRequest>();
	if (!command((std::string() + "SELECT * FROM Users WHERE USER_NAME = \"" + userName + "\""
		+ "AND PASSWORD = \"" + password +"\";"), getUsers, (void*)&users))
		std::cout << "Err check if exist" << std::endl;
	return !users.empty();
}

void SqliteDatabase::addNewUser(std::string userName, std::string password, std::string email)
{
	if (!command(std::string() + "INSERT INTO Users (USER_NAME, PASSWORD, EMAIL) "//add the new user to the DB
		+ "VALUES (\"" + userName + "\", \"" + password + "\", \"" + email + "\");"))
		throw std::invalid_argument("Cant add new user: " + std::string() + userName);
	command(std::string() + "INSERT INTO Statistics (GamesTotal, QuestionsTotal, CorrectTotal, AVG_Time, USER_NAME) "//set default
		+ "VALUES (0, 0, 0, 0, \"" + userName + "\")");
}

//2.0.0V
void SqliteDatabase::insertStartQuestions()
{
	if (!command(std::string() + "INSERT INTO Questions (Question, WrongAnswers, CorrectAnswer) "//add the new user to the DB
		+ "VALUES (\"Who is the best educator in c++ Magshimim curse?\",\"Matan Anavi;Osher from Be'er Sheva;Gilad from Ashdod\",\"Amir Rivlin\"),"
		+ "(\"Who caused the dismissal of Matan Anavi?\",\"Elinoam;Shahar Trabelsi;Avi Yegudayev\",\"Matan Anavi\"),"
		+ "(\"Who break the world record of giving F in tasks in Magshimim?\",\"Gali Cohavi;Amir Rivlin;Gilad from Ashdod\",\"Matan Anavi\"),"
		+ "(\"What is the meanining of life?\",\"Money;Fun;Family\",\"42\"),"
		+ "(\"1 + 1 = ?\",\"0;13;53\",\"2\"),"
		+ "(\"Who get into a gang fight recently?\",\"Muhamad Ali;Eyal Golan;Matan Anavi\",\"Dekel Vaknin\"),"
		+ "(\"Where the corona virus Start?\",\"Israel;USA;UK\",\"China\"),"
		+ "(\"a^2 * b^3, What is True?\",\"0 < a^3;0 < a * b;0 < b^-1\",\"0 < (-b)\"),"
		+ "(\"1 < a^b, b < 0, What isn't possitive?\",\"a^2b;a^(-b);(-a)^0\",\"(-a)^b\"),"
		+ "(\"Who recently preform the song sof ona?\",\"Eyal Golan;Moshe Perez;Aviv Gefen\",\"Dekel Vaknin\");"))
		throw std::invalid_argument("Cant add q");
}

std::list<Question> SqliteDatabase::getQuestion(int number)
{
	std::list<Question> q = std::list<Question>();
	if (!command((std::string() + "SELECT * FROM Questions;"), getQuestions, (void*)&q))
		std::cout << "Cant get Questions" << std::endl;
	if (number > q.size()) number = q.size();//if this to big
	if (number < 1) number = 1;//if this to small
	std::vector<Question> questions(q.begin(), q.end());
	std::shuffle(std::begin(questions), std::end(questions), rng);//mix the questions
	for (std::vector<Question>::iterator it = questions.begin(); it != questions.end() && it->getQuestion() != questions[number].getQuestion(); it++)
	{//mix the answers
		std::vector<std::string> answers = it->m_possivleAnswers;
		std::string corectAns = it->getCorrectAnswer();//save the correct ans
		std::shuffle(std::begin(answers), std::end(answers), rng);//mix the ans
		it->m_possivleAnswers = answers;
		it->num_correctAnswer = std::distance(answers.begin(), std::find(answers.begin(), answers.end(), corectAns));//get the index of correct answer in the answers
	}
	return std::list<Question>(questions.begin(), questions.begin() + number);
}

float SqliteDatabase::getPlayerAverageAnswerTime(std::string player)
{
	std::list<int> time = std::list<int>();
	//get the gamesQ of the player
	if (!command((std::string() + "SELECT AVG_Time FROM Statistics WHERE USER_NAME = \"" + player + "\";"), getNumbers, (void*)&time))
		std::cout << "Err check if exist" << std::endl;
	return time.empty() ? 0 : time.back();
}

int SqliteDatabase::getNumOfCorrectAnswers(std::string player)
{
	std::list<int> RightQ = std::list<int>();
	//get the gamesQ of the player
	if (!command((std::string() + "SELECT CorrectTotal FROM Statistics WHERE USER_NAME = \"" + player + "\";"), getNumbers, (void*)&RightQ))
		std::cout << "Err check if exist" << std::endl;
	return RightQ.empty() ? 0 : RightQ.back();
}

int SqliteDatabase::getNumOfTotalAnswers(std::string player)
{
	std::list<int> totalQ = std::list<int>();
	//get the gamesQ of the player
	if (!command((std::string() + "SELECT QuestionsTotal FROM Statistics WHERE USER_NAME = \"" + player + "\";"), getNumbers, (void*)&totalQ))
		std::cout << "Err check if exist" << std::endl;
	return totalQ.empty() ? 0 : totalQ.back();
}

int SqliteDatabase::getNumOfPlayerGames(std::string player)
{
	std::list<int> totalGames = std::list<int>();
	//get the gamestotal of the player
	if (!command((std::string() + "SELECT GamesTotal FROM Statistics WHERE USER_NAME = \"" + player + "\";"), getNumbers, (void*)&totalGames))
		std::cout << "Err check if exist" << std::endl;
	return totalGames.empty() ? 0 : totalGames.back();
}

std::vector<std::string> SqliteDatabase::getUserNames()
{
	std::list<SignupRequest> users = std::list<SignupRequest>();
	if (!command((std::string() + "SELECT * FROM Users;"), getUsers, (void*)&users))
		std::cout << "Err getUsers" << std::endl;
	std::vector<std::string> names;
	for (SignupRequest name : users)
		names.push_back(name.username);
	return names;
}

void SqliteDatabase::setNewStatistics(int QuestionsTotal, int CorrectTotal, float AVG_Time, std::string username)
{
	if (!command(std::string() + "UPDATE Statistics"//add the new user to the DB
		+ " SET GamesTotal = " + std::to_string(getNumOfPlayerGames(username) + 1)
		+ ", QuestionsTotal = " + std::to_string(QuestionsTotal + getNumOfTotalAnswers(username))
		+ ", CorrectTotal = " + std::to_string(CorrectTotal + getNumOfCorrectAnswers(username))
		+ ", AVG_Time = " + std::to_string(AVG_Time)
		+ " WHERE USER_NAME = \"" + username + "\";"))
		throw std::invalid_argument("Cant add new statistcs for " + username);
}

