using System;

using System.Text;
using System.Globalization;

namespace BootCamp.Chapter
{
    public static class BalanceStats
    {
        /// <summary>
        /// Return name and balance(current) of person who had the biggest historic balance.
        /// </summary>
        public static string FindHighestBalanceEver(string[] peopleAndBalances)
        {
            if (IsNullOrEmpty(peopleAndBalances)) return "N/A.";

            string person="";
            float highBalance = 0;
            float value;
            
            int personCount = 1;
            string[] people = new string[personCount];

            for (int i=0; i<peopleAndBalances.Length; i++)
            {
                var personString = peopleAndBalances[i];
                string[] personDetails = personString.Split(", ");
                
                for (int j=1; j<personDetails.Length; j++)
                {
                    string strVal = personDetails[j];

                    value = float.Parse(strVal, CultureInfo.InvariantCulture.NumberFormat);

                    if (value > highBalance)
                    {
                        personCount = 1;
                        people = new string[personCount];

                        highBalance = value;
                        person = personDetails[0];

                        people[0] = person;

                    }
                    else if (value == highBalance)
                    {
                        personCount++;
                        string[] peopleTemp = new string[personCount];

                        person = personDetails[0];

                        people = Transfer(people, peopleTemp, person);
                    }
                }
            }

            var message = new StringBuilder();

            message.Append(MessagePeopleBuild(people));

            var formattedVal = String.Format(CultureInfo.InvariantCulture, "{0:C}", (int)highBalance);
            message.Append($" had the most money ever. ¤{(int)highBalance}.");

            return message.ToString();
        }

        /// <summary>
        /// Return name and loss of a person with a biggest loss (balance change negative).
        /// </summary>
        public static string FindPersonWithBiggestLoss(string[] peopleAndBalances)
        {
            if (IsNullOrEmpty(peopleAndBalances)) return "N/A.";

            string person = "";
            float currentBalance = 0;
            float newVal;
            float oldVal;
            float diff = 0;
            float maxLoss = 0;

            int personCount = 1;
            string[] people = new string[personCount];


            for (int i = 0; i < peopleAndBalances.Length; i++)
            {
                var personString = peopleAndBalances[i];
                string[] personDetails = personString.Split(", ");

                if (personDetails.Length < 3) { continue; }

                for (int j = 2; j < personDetails.Length; j++)
                {
                    string strVal = personDetails[j];
                    string strVal2 = personDetails[j-1];
                    newVal = float.Parse(strVal, CultureInfo.InvariantCulture.NumberFormat); 
                    oldVal = float.Parse(strVal2, CultureInfo.InvariantCulture.NumberFormat);
                    diff = newVal - oldVal;

                    if (diff < maxLoss)
                    {
                        person = personDetails[0];
                        maxLoss = diff;

                        people[0] = person;
                    }
                    else if (diff == maxLoss)
                    {
                        personCount++;
                        string[] peopleTemp = new string[personCount];

                        person = personDetails[0];

                        people = Transfer(people, peopleTemp, person);
                    }
                }

            }

            if (people[0]==null) return "N/A.";

            var message = new StringBuilder();

            message.Append(MessagePeopleBuild(people));

            string str = "";

            if ((int)maxLoss < 0)
            {
                str = $"-¤{Math.Abs(maxLoss)}";
            }
            else
            {
                str = $"¤{Math.Abs(maxLoss)}";
            }

            if (people.Length == 1)
            {
                message.Append($" lost the most money. {str}.");
            }
            else
            {
                message.Append($" have lost the most money. {str}.");
            }

            return message.ToString();
        }

        /// <summary>
        /// Return name and current money of the richest person.
        /// </summary>
        public static string FindRichestPerson(string[] peopleAndBalances)
        {
            if (IsNullOrEmpty(peopleAndBalances)) return "N/A.";

            string person = "";
            float highBalance = 0;
            float currentVal = 0;
            float value;

            int personCount = 1;
            string[] people = new string[personCount];

            for (int i = 0; i < peopleAndBalances.Length; i++)
            {
                var personString = peopleAndBalances[i];
                string[] personDetails = personString.Split(", ");

                for (int j = 1; j < personDetails.Length; j++)
                {
                    string strVal = personDetails[j];

                    value = float.Parse(strVal, CultureInfo.InvariantCulture.NumberFormat);

                    if (value > highBalance)
                    {
                        personCount = 1;
                        people = new string[personCount];

                        highBalance = value;
                        person = personDetails[0];
                        currentVal = float.Parse(personDetails[personDetails.Length-1], CultureInfo.InvariantCulture.NumberFormat);

                        people[0] = person;

                    }
                    else if (value == highBalance)
                    {
                        personCount++;
                        string[] peopleTemp = new string[personCount];

                        person = personDetails[0];

                        people = Transfer(people, peopleTemp, person);
                    }
                }
            }

            var message = new StringBuilder();

            message.Append(MessagePeopleBuild(people));

            if (people.Length == 1)
            {
                message.Append($" is the richest person. ¤{(int)currentVal}.");
            }
            else
            {
                message.Append($" are the richest people. ¤{(int)currentVal}.");
            }

            return message.ToString();
        }

        /// <summary>
        /// Return name and current money of the most poor person.
        /// </summary>
        public static string FindMostPoorPerson(string[] peopleAndBalances)
        {

            if (IsNullOrEmpty(peopleAndBalances)) return "N/A.";

            string person = "";
            float lowBalance = float.MaxValue;
            float value;

            int personCount = 1;
            string[] people = new string[personCount];

            for (int i = 0; i < peopleAndBalances.Length; i++)
            {
                var personString = peopleAndBalances[i];
                string[] personDetails = personString.Split(", ");

                value = float.Parse(personDetails[personDetails.Length - 1]);

                if (value < lowBalance)
                {
                    personCount = 1; 
                    people = new string[personCount];

                    person = personDetails[0];
                    lowBalance = float.Parse(personDetails[personDetails.Length - 1], CultureInfo.InvariantCulture.NumberFormat);

                    people[0] = person;
                }
                else if (value == lowBalance)
                {
                    personCount++;
                    string[] peopleTemp = new string[personCount];

                    person = personDetails[0];

                    people = Transfer(people, peopleTemp, person);
                }


            }

            var message = new StringBuilder();

            message.Append(MessagePeopleBuild(people));

            string str = "";

            if ((int)lowBalance < 0)
            {
                str = $"-¤{Math.Abs(lowBalance)}";
            }
            else
            {
                str = $"¤{Math.Abs(lowBalance)}";
            }

           

            if (people.Length == 1)
            {
                message.Append($" has the least money. {str}.");
            }
            else
            {
                message.Append($" have the least money. {str}.");
            }

            return message.ToString();

            return $"{person}, {lowBalance}";
        }

        private static string[] Transfer(string[] mainList, string[] tempList, string newAdd)
        {
            for (int i = 0; i < mainList.Length; i++)
            {
                tempList[i] = mainList[i];
            }

            tempList[tempList.Length - 1] = newAdd;

            mainList = new string[tempList.Length];

            for (int i = 0; i < tempList.Length; i++)
            {
                mainList[i] = tempList[i];
            }

            return mainList;
        }

        private static string MessagePeopleBuild(string[] peopleList)
        {
            var message = new StringBuilder();

            if (peopleList.Length == 1)
            {
                message.Append(peopleList[0]);
            }
            else
            {
                for (int i = 0; i < peopleList.Length; i++)
                {
                    if (i == peopleList.Length - 2)
                    {
                        message.Append($"{peopleList[i]} and ");
                    }
                    else if (i == peopleList.Length - 1)
                    {
                        message.Append($"{peopleList[i]}");
                    }
                    else
                    {
                        message.Append($"{peopleList[i]}, ");
                    }

                }

            }

            return message.ToString();

        }

        private static bool IsNullOrEmpty(string[] array)
        {
            return (array == null || array.Length == 0);
        }
    }
}
