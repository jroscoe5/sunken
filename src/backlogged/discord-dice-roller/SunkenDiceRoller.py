# UNFINISHED AND BACKLOGGED

import random
import discord

class SunkenDiceRoller(discord.Client):

    def __init__(self):
        super().__init__()
        self.__reactions = ['😀','😃','😄','😁','😆','😅','🤣','😂']

    async def on_ready(self):
        print('Connected to Discord as: ' + str(self.user))
        await self.change_presence(activity=discord.Game('Sunken'))

    async def on_message(self, msg):
        # wrap everthing in a try because im lazy
        try:
            # if message is from the bot, react to it
            if msg.author == self.user:
                self.react_to_msg(msg)
                return
            
            if msg.content.strip() == '!roll':
                await msg.channel.send(self.roll_dice(8))
                return
            
            if msg.content[:5] == '!roll':
                await msg.content.send(self.roll_dice(int(msg.content[5])))
        except Exception as exc:
            return

    async def on_reaction_add(self, reaction, user):
        # dont trigger on self reactions
        if user == self.user:
            return
        try:
            if reaction.message.author != self.user:
                return
        except Exception as exc:
            return
    
    def react_to_msg(self, msg):
        rolls = (len(msg.content) - 5)/11
        for i in range(rolls):
            await msg.add_reaction(self.__reactions[i])
        
    def editMessage(self, msg, pos):
        original = msg.content
        edited = original[:pos] + str(random.randint(1,6)) + original[pos + 1:]
        await msg.edit(content=edited)


    def roll_dice(self, num):
        if num > 8:
            num = 8
        rolls = [random.randint(1,6) for _ in range(num)]
        text = "....."
        for roll in rolls:
            text += str(roll) + "          "
        return text
