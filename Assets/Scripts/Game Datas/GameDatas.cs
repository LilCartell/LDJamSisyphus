
using System.Collections.Generic;
using System.Linq;

public class GameDatas
{
    private static GameDatas _instance;
    public static GameDatas Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameDatas();
            return _instance;
        }
    }

    private List<PlacableItemArchetype> _placableItemArchetypes = new List<PlacableItemArchetype>()
    {
        new PlacableItemArchetype()
        {
            ItemType = PlacableItemType.FORWARD_RECTANGLE,
            Name = "/",
            PrefabPath = "Prefabs/PlacableItems/ForwardRectangle",
            Cost = 100
        },
        new PlacableItemArchetype()
        {
            ItemType = PlacableItemType.BACKWARD_RECTANGLE,
            Name = "\\",
            PrefabPath = "Prefabs/PlacableItems/BackwardRectangle",
            Cost = 100
        }
    };

    private GameDatas()
    { }

    public List<PlacableItemArchetype> GetPassableItemArchetypes()
    {
        return _placableItemArchetypes;
    }

    public PlacableItemArchetype GetPlacableItemArchetypeByType(PlacableItemType itemType)
    {
        return _placableItemArchetypes.First(archetype => archetype.ItemType == itemType);
    }
}