
namespace TODO
{
    public class Task
    {
        public string _name;
        public bool _ready = false;
        public int _user = 0;

        public Task()
        {

        }

        public Task(string name, bool ready)
        {
            _name = name;
            _ready = ready;
        }

        public Task(string name, bool ready, int user)
        {
            _name = name;
            _ready = ready;
            _user = user;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
