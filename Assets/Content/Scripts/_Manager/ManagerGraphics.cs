using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGraphics : MonoBehaviour {

	public List<Graphic> graphics;
	public List<Arc> boards;
	public List<Arc> hands;

    public void updateGraphics(List<Character> characters, List<Card> cards) {

        // Iterate over each controller
        for (int controllerIndex = 0; controllerIndex < 2; controllerIndex++)
		{
            // Add all minions to board
			var minions = characters.FindAll(_ => _.controller == controllerIndex
											 && _.entity.type == EntityType.Minion);

			for (int i = 0; i < minions.Count; i++)
			{
				var item = minions[i];
				var t = 0.5f;
				if (minions.Count > 1)
				{
                    t += i * (1f / 6f);
                    t -= ((minions.Count - 1f) / 6f) / 2f;
				}
				var position = boards[controllerIndex].evaluate(t);
				var card = Instantiate(Resources.Load("Prefab Minion"), position, Quaternion.identity);
                (card as GameObject).GetComponent<GraphicMinion>().index = i;
			}

			// Add all cards to hand
			var cardsFind = cards.FindAll(_ => _.controller == controllerIndex);

			for (int i = 0; i < cardsFind.Count; i++)
			{
				var item = cardsFind[i];
				var t = 0.5f;
				if (minions.Count > 1)
				{
					t += i * (1f / 6f);
					t -= ((minions.Count - 1f) / 6f) / 2f;
				}
				var position = hands[controllerIndex].evaluate(t);
				var card = Instantiate(Resources.Load("Prefab Card"), position, Quaternion.identity);
			    (card as GameObject).GetComponent<GraphicCard>().index = i;
            }

        }
    }
}
