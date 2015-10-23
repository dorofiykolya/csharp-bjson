using System;

namespace Common.Records
{
    public class SoundsRecord
    {
        public SoundsRecord()
        {
        }

        public SoundsRecord(string setId, string setValue)
        {
            id = setId;         // id звука. Совпадает с именем GameObject'a в иерархии МастерАудио
            value = setValue;   // Путь к файлу. Либо локальный либо по http на сервере
        }

        public string id;       // id звука. Совпадает с именем GameObject'a в иерархии МастерАудио
        public string value;    // Путь к файлу. Либо локальный либо по http на сервере


        public override string ToString()
        {
            return "{" + id + ":" + value + "}";
        }

    }
}
