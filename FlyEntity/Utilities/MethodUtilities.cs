using FlyEntity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlyEntity.Utilities
{
    public static class MethodUtilities
    {
        //public static List<Fly_Partnership> GetAllParnership() {
        //    PartnershipDAO partnership = new PartnershipDAO();
        //    return partnership.getAllItemsWidthPicture().ToList();
        //}

        public static IEnumerable<T> ExceptBy<T, TKey>(this IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKey)
        {
            var rs = from item in items
                   join otherItem in other on getKey(item)
                   equals getKey(otherItem) into tempItems
                   from temp in tempItems.DefaultIfEmpty()
                   where ReferenceEquals(null, temp) || temp.Equals(default(T))
                   select item;
            return rs;
        }

        public static void Update<T>(this System.Data.Entity.DbContext context,T entityObject, T OldentityObject) where T : class
        {

           
            //context.Set<T>().Attach(entityObject);
            //var entry = context.Entry(entityObject);

            //var typeNew = typeof(T);
            //var typeOld = OldentityObject.GetType();

            //foreach (PropertyInfo pi in typeNew.GetProperties(BindingFlags.SetProperty | BindingFlags.GetProperty))
            //{
            //    var newValue = typeNew.GetProperty(pi.Name).GetValue(entityObject, null);

            //    foreach (PropertyInfo piOld in typeOld.GetProperties(BindingFlags.SetProperty | BindingFlags.GetProperty))
            //    {
            //        var oldValue = typeOld.GetProperty(piOld.Name).GetValue(piOld.Name, null);
            //        if (piOld.Name.Equals(pi.Name) && !oldValue.Equals(newValue))
            //        {
            //            typeOld.GetProperty(piOld.Name).SetValue(piOld.Name, newValue, null);
            //        }
            //    }

            //}

            //foreach (PropertyInfo item in typeOld.GetProperties(BindingFlags.SetProperty | BindingFlags.GetProperty))
            //{
            //    OldentityObject.GetType().GetProperty(item.Name).SetValue(item.Name, item.GetValue(item.Name));
            //}

            //var abc = typeOld;

            //foreach (string name in entry.CurrentValues.PropertyNames)
            //{
            //    Console.WriteLine("print :" + name);
            //}

        }


        public static string GetCaptchaString(int length)
        {
            int intZero = '0';
            int intNine = '9';
            int intA = 'A';
            int intZ = 'Z';
            int intCount = 0;
            int intRandomNumber = 0;
            string strCaptchaString = "";

            Random random = new Random(System.DateTime.Now.Millisecond);

            while (intCount < length)
            {
                intRandomNumber = random.Next(intZero, intZ);
                if (((intRandomNumber >= intZero) && (intRandomNumber <= intNine) || (intRandomNumber >= intA) && (intRandomNumber <= intZ)))
                {
                    strCaptchaString = strCaptchaString + (char)intRandomNumber;
                    intCount = intCount + 1;
                }
            }
            return strCaptchaString;
        }
    }
}
