﻿namespace WebApplication2.Controllers
{
    public class AdminService : IHiService
    {
        public string SayHi()
        {
            return "Hi from Admin Service";
        }
    }


    public class AdminService2 : IHiService
    {
        public string SayHi()
        {
            return "Hi from Admin Service test";
        }
    }
}
