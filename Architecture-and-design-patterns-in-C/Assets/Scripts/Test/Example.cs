using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Test
{
    internal sealed class Example
    {
        private void SelectWeapon()
        {
            StartGame(new PlayerFactory(new WeaponFactory()));
        }
        
        
        private void StartGame(PlayerFactory playerFactory)
        {
            IPlayer player1 = playerFactory.CreatePlayer(100.0f);
            // IPlayer player = new Player();
            Player.Factory.CreatePlayer(80);
            Inventory.CreateEmptyInventory();
        }

        public interface IPlayer
        {
            IWeapon Weapon { get; }
            float Health { get; }
        }

        public class Player : IPlayer
        {
            public IWeapon Weapon { get; }
            public float Health { get; }
            public static IPlayerFactory Factory { get; } = new PlayerFactory(new WeaponFactory());
            
            public Player(IWeapon weapon, float health)
            {
                Weapon = weapon;
                Health = health;
            }

            public static IPlayer CreateMag()
            {
                return new Player(null, Single.MaxValue);
            }

            public static IPlayer CreateOrg()
            {
                return new Player(null, Single.MaxValue);
            }
        }

        public interface IPlayerFactory
        {
            IPlayer CreatePlayer(float health);
        }

        public class PlayerFactory : IPlayerFactory
        {
            private readonly IWeaponFactory _weaponFactory;

            public PlayerFactory(IWeaponFactory weaponFactory)
            {
                _weaponFactory = weaponFactory;
            }
            
            public IPlayer CreatePlayer( float health)
            {
                return new Player(_weaponFactory.CreateWeapon(), health);
            }
        }

        public interface IWeapon
        {
            
        }

        public interface IWeaponFactory
        {
            IWeapon CreateWeapon();
        }

        public class WeaponFactory : IWeaponFactory
        {
            public IWeapon CreateWeapon()
            {
                throw new System.NotImplementedException();
            }
        }

        internal class Inventory : MonoBehaviour
        {
            private List<int> _list;
            public static Inventory CreateEmptyInventory()
            {
                var result = new GameObject("Inventory").AddComponent<Inventory>();

                result._list = new List<int>();
                return result;
            }
        }
    }
}
