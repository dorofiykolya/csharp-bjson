namespace Records.Initialization
{
    public class RewardLevelRecord
    {
        //уровень квеста
        public int level;
        
        //описание квеста
        public string description;

        //значение, которого нужно достичь
        public int value;

        //идентификаторы наград награды за квест
        public int[] rewards;
    }
}
