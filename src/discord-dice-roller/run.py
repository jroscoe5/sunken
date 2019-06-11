from SunkenDiceRoller import SunkenDiceRoller

file = open('auth\\token.dtoken')
token = file.readline()
file.close()
bot = SunkenDiceRoller()
bot.run(token)