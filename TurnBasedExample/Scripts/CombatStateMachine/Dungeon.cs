using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName="Game/Dungeon")]
public class Dungeon : ScriptableObject
{
    public Unit heroTemplate;
    public Unit monsterTemplate;
    public int nrOfRooms;

    // [System.NonSerialized]
    public List<Unit> heroes = new List<Unit>();
    // [System.NonSerialized]
    public List<Room> rooms = new List<Room>();
    [System.NonSerialized]
    private List<Unit> queuedHeroes = new List<Unit>();
    [System.NonSerialized]
    private List<Unit> queuedMonsters = new List<Unit>();

    [System.NonSerialized]
    private int currentRoomIndex = 0;

    void OnEnable ()
    {
        Populate();
        Debug.Log(rooms.Count);
    }

    void OnDisable ()
    {
        heroes = new List<Unit>();
        rooms = new List<Room>();
    }

    public void Populate ()
    {
        heroes.Add(ScriptableObject.Instantiate(heroTemplate));

        for (int i = 0; i < nrOfRooms; i++)
        {
            var room = new Room();
            room.monsters.Add(ScriptableObject.Instantiate(monsterTemplate));
            room.monsters.Add(ScriptableObject.Instantiate(monsterTemplate));
            room.monsters.Add(ScriptableObject.Instantiate(monsterTemplate));
            rooms.Add(room);
        }
    }

    public bool HasQueuedUnits ()
    {
        return queuedHeroes.Count + queuedMonsters.Count > 0;
    }

    public bool AllHeroesAreDead ()
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            if (!heroes[i].IsDead())
            {
                return false;
            }
        }

        return true;
    }

    public bool AllMonstersInCurrentRoomAreDead ()
    {
        var monsters = GetCurrentRoom().monsters;
        for (int i = 0; i < monsters.Count; i++)
        {
            if (!monsters[i].IsDead())
            {
                return false;
            }
        }

        return true;
    }

    public void AddUnitToQueue (Unit unit)
    {
        if (unit.isHero) 
        {
            queuedHeroes.Add(unit);
            queuedHeroes.Sort((a, b) => a.Initiative.CompareTo(b.Initiative));
        }
        else
        {
            queuedMonsters.Add(unit);
            queuedMonsters.Sort((a, b) => a.Initiative.CompareTo(b.Initiative));
        }
    }

    public Unit GetNextAttackingUnit ()
    {
        Unit unit;
        if (queuedHeroes.Count > 0)
        {
            unit = queuedHeroes[0];
            queuedHeroes.Remove(unit);
            return unit;
        }

        unit = queuedMonsters[0];
        queuedMonsters.Remove(unit);
        return unit;
    }

    public Unit GetNextDefendingUnit ()
    {
        return GetCurrentRoom().GetDefendingUnit();
    }

    public Room GetCurrentRoom ()
    {
        return rooms[currentRoomIndex];
    }

    public bool HasRoomsLeft ()
    {
        return currentRoomIndex < (rooms.Count + 1);
    }

    public void IncreaseRoomIndex ()
    {
        currentRoomIndex++;
    }
}