using System;
using System.Collections.Generic;
using System.Text;
using Sunken.Character;

namespace Sunken.TurnManagement
{
    public class TurnManager
    {
        public GameCharacter CurrentCharacter { get; protected set; }
        protected Queue<GameCharacter> CharacterList;
        public TurnManager()
        {
            CharacterList = new Queue<GameCharacter>();
        }
        public void Initialize(GameCharacter[] characters)
        {
            CharacterList.Clear();
            foreach (GameCharacter character in characters)
            {
                CharacterList.Enqueue(character);
            }
            CurrentCharacter = CharacterList.Peek();
        }
        public void AdvanceTurn()
        {
            if (CharacterList.Count == 0) return;
            CharacterList.Enqueue(CharacterList.Peek());
            CharacterList.Dequeue();
            CurrentCharacter = CharacterList.Peek();
        }
        public GameCharacter[] GetCurrentTurnOrder()
        {
            return CharacterList.ToArray();
        }
    }
}
