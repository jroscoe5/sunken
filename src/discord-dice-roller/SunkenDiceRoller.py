import discord
import random

class SunkenDiceRoller(discord.Client):
    async def on_ready(self):
        print('Connected to Discord as: ' + str(self.user))
        await self.change_presence(activity=discord.Game('Sunken'))

    async def on_message(self, msg):
        if(msg.author == self.user):
            await msg.add_reaction('😀')
            await msg.add_reaction('😃')
            await msg.add_reaction('😄')
            await msg.add_reaction('😁')
            await msg.add_reaction('😆')
            await msg.add_reaction('😅')
            await msg.add_reaction('🤣')
            await msg.add_reaction('😂')
            return

        if msg.content != '!roll':
            return
        text = self.rollDice()

        await msg.channel.send(text)

    async def on_reaction_add(self, reaction, user):
        if user == self.user:
            return
        if reaction.message.author != self.user:
            return
    
        if reaction.emoji == '😀':
            print('😀')
        
    def editMessage(self, msg, pos):
        original = msg.content
        



    def rollDice(self):
        # generate 8 dice rolls
        rolls = [random.randint(1,6) for _ in range(8)]
        text = "|    "
        for roll in rolls:
            text += str(roll) + "           "
        text += "|"
        return text
