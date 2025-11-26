using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Calendar : MonoBehaviour
{
    /// <summary>
    /// Cell or slot in the calendar. All the information each day should now about itself
    /// </summary>
    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;

        /// <summary>
        /// Constructor of Day
        /// </summary>
        public Day(int dayNum, Color dayColor, GameObject obj)
        {
            this.dayNum = dayNum;
            this.obj = obj;
            UpdateColor(dayColor);
            UpdateDay(dayNum);
        }

        /// <summary>
        /// Call this when updating the color so that both the dayColor is updated, as well as the visual color on the screen
        /// </summary>
        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor;
            dayColor = newColor;
        }

        /// <summary>
        /// When updating the day we decide whether we should show the dayNum based on the color of the day
        /// This means the color should always be updated before the day is updated
        /// </summary>
        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;
            if (dayColor == Color.white || dayColor == Color.green)
            {
                obj.GetComponentInChildren<TMP_Text>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<TMP_Text>().text = "";
            }
        }
    }


    /// <summary>
    /// All the days in the month. After we make our first calendar we store these days in this list so we do not have to recreate them every time.
    /// </summary>
    private List<Day> days = new List<Day>();

    /// <summary>
    /// Setup in editor since there will always be six weeks. 
    /// Try to figure out why it must be six weeks even though at most there are only 31 days in a month
    /// </summary>
    public Transform[] weeks;

    /// <summary>
    /// This is the text object that displays the current month and year
    /// </summary>
    public TMP_Text MonthAndYear;

    /// <summary>
    /// This is the text object that displays the current day and number.
    /// </summary>
    public TMP_Text NumberDay;
    /// <summary>
    /// this currDate is the date our Calendar is currently on. The year and month are based on the calendar, 
    /// while the day itself is almost always just 1
    /// If you have some option to select a day in the calendar, you would want the change this objects day value to the last selected day
    /// </summary>
    public DateTime currDate = DateTime.Now;

    /// <summary>
    /// In start we set the Calendar to the current date
    /// </summary>
    /// 
    public int activeDay;

    public int counterId = 0;

    public TextAsset jsonFile;

    public TextosEventos contenido;

    [Serializable]
    public class Mensaje
    {
        public int dia;
        public int mes;
        public int anno;
        public int id;
        public string mensaje;
    }

    [Serializable]
    public class Mensajes
    {
        public List<Mensaje> mensajes;
    }
    public Mensajes listaMensajes;
    private void Start()
    {
        UpdateCalendar(DateTime.Now.Year, DateTime.Now.Month);
        listaMensajes = JsonUtility.FromJson<Mensajes>(jsonFile.text);

        if(listaMensajes != null)
        { 
            counterId = listaMensajes.mensajes.Count;
            contenido.updateContend();
        }
        else
        {
            listaMensajes = new Mensajes();
            listaMensajes.mensajes = new List<Mensaje>();
        }
            activeDay = -1;
    }

    /// <summary>
    /// Anytime the Calendar is changed we call this to make sure we have the right days for the right month/year
    /// </summary>
    void UpdateCalendar(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        currDate = temp;
        MonthAndYear.text = temp.ToString("MMMM") + " " + temp.Year.ToString();
        //NumberDay.text = temp.DayOfWeek.ToString() + " " + temp.Day.ToString();
        int startDay = GetMonthStartDay(year, month);
        int endDay = GetTotalNumberOfDays(year, month);
        activeDay = -1;

        ///Create the days
        ///This only happens for our first Update Calendar when we have no Day objects therefore we must create them

        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;
                    if (currDay < startDay || currDay - startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey, weeks[w].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.white, weeks[w].GetChild(i).gameObject);
                    }
                    days.Add(newDay);
                }
            }
        }
        ///loop through days
        ///Since we already have the days objects, we can just update them rather than creating new ones
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if (i < startDay || i - startDay >= endDay)
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }

                days[i].UpdateDay(i - startDay);
            }
        }

        ///This just checks if today is on our calendar. If so, we highlight it in green
        if (DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day - 1) + startDay].UpdateColor(Color.green);
        }

    }

    /// <summary>
    /// This returns which day of the week the month is starting on
    /// </summary>
    public int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);

        //DayOfWeek Sunday == 0, Saturday == 6 etc.
        return (int)temp.DayOfWeek;
    }

    /// <summary>
    /// Gets the number of days in the given month.
    /// </summary>
    int GetTotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    /// <summary>
    /// This either adds or subtracts one month from our currDate.
    /// The arrows will use this function to switch to past or future months
    /// </summary>
    public void SwitchMonth(int direction)
    {
        if (direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }

        UpdateCalendar(currDate.Year, currDate.Month);
    }

    public void ActtivarDia(TMP_Text dia)
    {
        if(dia.text.ToString() != "")
        {
            if (activeDay >= 0)
            {
                days[activeDay].UpdateColor(Color.white);
            }
            if (DateTime.Now.Year == currDate.Year && DateTime.Now.Month == currDate.Month)
            {
                days[(DateTime.Now.Day - 1) + GetMonthStartDay(currDate.Year, currDate.Month)].UpdateColor(Color.green);
            }
            activeDay = Int32.Parse(dia.text) + GetMonthStartDay(currDate.Year, currDate.Month) - 1;
            days[activeDay].UpdateColor(Color.yellow);
        }
    }

    public void GuardarInfo(string input)
    {
        Mensaje msg = new Mensaje();
        /*
        string dia = activeDay.ToString();
        if (activeDay < 10)
        {
            dia = "0" + dia;
        }
        string mes = currDate.Month.ToString();
        if (currDate.Month < 10)
        {
            mes = "0" + mes;
        }
        */
        //string key = dia + mes;

        msg.dia = activeDay;
        if (activeDay < 0)
        {
            msg.dia = DateTime.Now.Day + GetMonthStartDay(DateTime.Now.Year, DateTime.Now.Month) - 1;
        }
        msg.mes = currDate.Month;
        msg.id = ++counterId;
        msg.mensaje = input;
        msg.anno = currDate.Year;
        /*
        Mensajes tempMensajes = new Mensajes();
        tempMensajes.mensaje = listaMensajes.mensaje;
        listaMensajes.mensaje = new List<Mensaje>();
        for(int i = 0; i < tempMensajes.mensaje.Count; i++)
        {
            listaMensajes.mensaje[i] = tempMensajes.mensaje[i];
        }
        */
        listaMensajes.mensajes.Add(msg);
        //string jsonOutput = "{" + '\u0022' + key + '\u0022' + ":" + '\u0022' + input + '\u0022' + "}";
        string jsonOutput = JsonUtility.ToJson(listaMensajes);
        Debug.Log(jsonOutput);
        File.WriteAllText(Application.dataPath + "/JsonEvento.txt", jsonOutput);
        contenido.updateContend();
    }
}