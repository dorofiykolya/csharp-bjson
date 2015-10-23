namespace Records.Initialization
{
    public class SpellActionRecord
    {
        // уникальный идентификатор
        public int id;

        // тип
        public int actionType;

        //время действия
        public int actionTime;

        // количество срабатываний;
        public int numberOfApplications;

        // количество шагов между срабатываниями спелла
        public int stepsBetweenApplications;

        // количество шагов, который действуее спелл после применения;
        public int actionSteps;

        // радиус, в котором “работает” спелл
        public int range;

        // тип целей, к которым применяется (0 — ни к каким, 1 — только наземные, 2 — только воздушные, 3 — любые)
        public int targetsType;

        // идентификатор наносимого урона
        public int damageId;

        //какой-то параметр (по необходимости)
        public int param1;

        //какой-то параметр (по необходимости)
        public int param2;
    }
}
