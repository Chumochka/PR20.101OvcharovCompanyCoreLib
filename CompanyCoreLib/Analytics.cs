using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCoreLib
{
    public class Analytics
    {
        //вспомогательгнгый класс, который поможет отсортировать даты по частоте использования
        public class DateTimeWithCounter
        {
            public DateTime DateTimeProp;
            public int Counter;
        }
        public List<DateTime> PopularMonths(List<DateTime> dates)
        {
            //объявляем временный массив объектов "ДатаСоСчетчиком"
            var DateTimeWithCounterList = new List<DateTimeWithCounter>();
            //Тут сразу можно сделать проверку на длину исходного массива
            //Перебираем исходный массив
            foreach(DateTime date in dates)
            {
                //Вычисляем начало месяца для даты текущего элемента массива
                var DateMonthStart = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
                //ищем эту дату во вспомогательном массиве
                var index = DateTimeWithCounterList.FindIndex(i => i.DateTimeProp == DateMonthStart);
                //index содержит позицию найденного элемента в массиве или -1, если не найдено
                if (index == -1)
                {
                    //такой даты нет - добавляю
                    DateTimeWithCounterList.Add(new DateTimeWithCounter { DateTimeProp = DateMonthStart, Counter = 1 });
                }
                else
                {
                    //дата есть - увеличиваем счетчик
                    DateTimeWithCounterList[index].Counter++;
                }
            }
            //вспомогательный массив сортируем по убыванию счетчика, затем по дате по возврастанию
            //выбираем из объекта только дату, счетчик нам уже не нужен
            return DateTimeWithCounterList.OrderByDescending(i => i.Counter).ThenBy(i => i.DateTimeProp).Select(i => i.DateTimeProp).ToList();
        }
    }
}
