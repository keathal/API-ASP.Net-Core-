/journal get (без параметров) – получает весь список рабочих мест

/journal post (string city, string country, float latitude, float longtitude) – добавляет город и страну

/journal/2 get (string token) – получает рабочие места с фильтром по id группы

/journal/companies get (string token) – получает список компаний

/group get (без параметров) – получает список групп

/login post (string surname, string name, string patr, DateTime date, string answer) – проверяет ответ на вопрос

/login get (int id, string surname, string name, string patr, DateTime date) – получает вопрос

/user/1 get (string token) – получает информацию о пользователе

/user/1 post (string token, int id, int id_city, string company, string link, string post, int salary, int id_currency, bool canShow, DateTime dateStart, DateTime dateEnd) – добавляет запись о рабочем месте пользователя

/user post (string token, int id, int contactTypeId, string value) – создает контакт пользователя

/user delete (string token, int id, int id_work) – удаляет запись о рабочем месте пользователя

/auth/token post (string username = “admin”, string password = “pass”) – получает токен, действительный 30 минут
