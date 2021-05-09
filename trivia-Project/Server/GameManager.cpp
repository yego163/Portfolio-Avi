#include "GameManager.h"


GameManager::GameManager(IDatabase* db)
{
    _db = db;
}

Game* GameManager::createGame(Room room)
{
    std::list<Question> qTemp = _db->getQuestion(room.getRoomData().getQuestionCount());
    std::vector<Question> questions{ std::make_move_iterator(qTemp.begin()),
                                 std::make_move_iterator(qTemp.end()) };//convert list to vector

    std::map<LoggedUser, GameData> dataOfGame;
    std::vector<LoggedUser> users = room.getAllUsers();
    for (size_t i = 0; i < users.size(); i++)//create the map for the constructor                     set the first Q to the default one (correct ans = -10)
        dataOfGame.insert(std::pair<LoggedUser, GameData>(users[i], GameData{ Question("FirstQ", std::vector<std::string>(), -10), 0, 0, 0 }));
    m_games.push_back(new Game(dataOfGame, questions));
	return m_games.back();//get the last game that created
}

void GameManager::deleteGame(int idOfGame)
{
    m_games.erase(std::remove_if(m_games.begin(), m_games.end(), [&idOfGame](const Game* game)->bool
    {
        return game->getId() == idOfGame;
    }), m_games.end());
}

std::vector<Game*>& GameManager::getM_games()
{
    return m_games;
}

bool GameManager::GameExits(Game* game)
{
    std::vector<Game*>::iterator it;
    it = std::find(m_games.begin(), m_games.end(), game);
    return it != m_games.end();
}
