namespace Records.Initialization
{
    public class FaqRecord
    {
         //тип ЧАВО (0 — обычные, 1 — карта, 2 — битва кланов)
        public int type;
         //вопрос
        public string question;
        // ответ
        public string answer;
        // массив ключей-тегов для ответа
        public string[] tags;
    }
}
