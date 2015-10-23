namespace Records.Initialization
{
    public class TriggerRecord
    {
        public int id;
        public int type;

        //тип целей, на которые срабатывает (0 — ни на какие; 1 — наземные; 2 — воздушные; 3 — наземные и воздушные)
        public int targetsType;

        //радиус срабатывания
        public int range;

        //идентификатор урона, который наносится, или действия-спелла, которое активируется
        public int actionId;
    }
}
