    
namespace HomeWork_3
{
    public static class UserData
    {

        public static Registration CreateUser()
        {
            return new Registration
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Password = "passwd",
                DateDropDown = "3",
                MonthsDropDown = "3",
                YearDropDown = "2016",
                Address = "Bulgaria",
                City = "Sofia",
                StateDropDown = "3",
                ZipCode = "58003",
                MobilePhone = "0888555444",
                AliasAddress = "Sofia"
            };
        }
    }
}
