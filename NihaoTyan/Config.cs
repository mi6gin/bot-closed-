using System;

namespace Nihao
{
    static class Config
    {
        public static readonly string Token = Environment.GetEnvironmentVariable("BOT_TOKEN");
    }
}
