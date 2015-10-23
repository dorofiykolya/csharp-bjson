using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Locations.Battle
{
    public class TWordMatrix : TBaseMatrix<ushort>
    {
        public TWordMatrix(int x, int y)
            : base(x, y)
        {
        }

        public override ushort this[int x, int y]
        {
            get
            {
                var result = base[x, y];
                return result;
            }
            set
            {
                var lastValue = base[x, y];
                base[x, y] = value;
            }
        }
    }

    public class TMoveMatrix : TBaseMatrix<int>
    {
        public TMoveMatrix(int x, int y)
            : base(x, y)
        {
        }

        public override int this[int x, int y]
        {
            get
            {
                var result = base[x, y];
                return result;
            }
            set
            {
                var lastValue = base[x, y];
                base[x, y] = value;
            }
        }
    }

    public class TByteMatrix : TBaseMatrix<byte>
    {
        public TByteMatrix(int x, int y)
            : base(x, y)
        {
        }

        public override byte this[int x, int y]
        {
            get
            {
                var result = base[x, y];
                return result;
            }
            set
            {
                var lastValue = base[x, y];
                base[x, y] = value;
            }
        }
    }

    public class TBoolMatrix : TBaseMatrix<bool>
    {
        public TBoolMatrix(int x, int y)
            : base(x, y)
        {
        }

        public override bool this[int x, int y]
        {
            get
            {
                var result = base[x, y];
                return result;
            }
            set
            {
                var lastValue = base[x, y];
                base[x, y] = value;
            }
        }
    }

    public class TBaseMatrix<T> : IEnumerable<T>
    {
        private readonly T[,] _matrix;

        private readonly int _sizeX;
        private readonly int _sizeY;

        public TBaseMatrix(int x, int y)
        {
            _matrix = new T[x, y];
            _sizeX = x;
            _sizeY = y;
        }

        public virtual void Reset()
        {
            Array.Clear(_matrix, 0, _matrix.Length);
        }

        public virtual T this[int x, int y]
        {
            get
            {
                var result = _matrix[x, y];
                return result;
            }
            set
            {
                var lastValue = _matrix[x, y];
                _matrix[x, y] = value;
            }
        }

        public int Length
        {
            get { return _matrix.Length; }
        }

        public int GetLength(int dimension)
        {
            return _matrix.GetLength(dimension);
        }

        public int SizeX { get { return _sizeX; } }

        public int SizeY { get { return _sizeY; } }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_matrix.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _matrix.GetEnumerator();
        }
    }

    [Serializable]
    public enum TFightType
    {
        ftTutorialMultiplayer = -2,
        ftTutorial = -1,
        ftSingleCampaign = 0,
        ftSingleUsers,
        ftSingleUsersMap,
        ftSingleMapLocation,
        ftSingleUsersClansDuels,
        ftSingleFriendLocation,
        ftSingleSelfAttack,
        ftSingleMission
    }

    public enum TBuildingType
    {
        btCommandCenter,
        btTechLab,
        btSpellFactory,
        btResourceMine,
        btSupplyDepot,
        btBuildersHut,
        btArmyCamp,
        btBarracks,
        btClanCastle,
        btDefense,
        btBomb,
        btWall,
        btDecoration,
        btObstacle,
        btHeroHouse,
        btArtefactStore,
        btFlagpole,
        btMapBomb,
        btTrash,
        btNew1,
        btNew2,
        btNew3,
        btNew4
    }

    public enum TDefBuildingType
    {
        fbtNone,
        fbtCannon,
        fbtWatchTower,
        fbtMortair,
        fbtFireTower,
        fbtAntiAir,
        fbtBunker,
        fbtToxinThrower,
        fbtTeslaOneTarget,
        fbtTeslaMultiTarget,
        fbtBomb,
        fbtBombWithMaxSize
    }

    public enum TUnitType
    {
        utNone,
        utPirate,
        utArcher,
        utFatso,
        utGrenadier,
        utBerserker,
        utShaman,
        utBouncer,
        utGiant,
        utWallBreaker,
        utThief,
        utBalloon,
        utHealer,
        utSharkmen,
        utCrabmen,
        utReptile,
        utDragon,
        utGroundHero,
        utAirHero
    }

    public enum TMoveType
    {
        mtNone,
        mtGround,
        mtAir
    }

    public enum TTargetsType
    {
        ttNone,
        ttGround,
        ttAir,
        ttAny
    }

    public enum TPreferredTarget
    {
        ptNone,
        ptResources,
        ptDefense,
        ptWall
    }

    public enum TLandingOwnerType
    {
        loNone,
        loUser,
        loClanHall,
        loHeroHouse,
        loOps
    }

    public enum TTriggerType
    {
        trNone,
        trGroundBomb,
        trAirBomb,
        trHiddenBuilding,
        trUnitGround,
        trUnitAny,
        trAttackUnitLanding,
        trDefenseUnitLanding,
        trDefenseHeroLanding,
        trFlagpoleUnitLanding,
        trUnitsSlowdown,
        trUnitsFreeze,
        trBomb,
        trGroundUnitsSlowdown
    }

    public enum TStatsModifier
    {
        smNone,
        smAttack,
        smDefense,
        smSpeed,
        smRageAttack,
        smRageSpeed,
        smSlow
    }

    public class StatsModifiersData : List<int>
    {
        public StatsModifiersData() : base(new int[Enum.GetValues(typeof(TStatsModifier)).Length]) { }

        public int this[TStatsModifier index]
        {
            get { return base[(int)index]; }
            set { base[(int)index] = value; }
        }

        public void Reset()
        {
            for (var i = 0; i < Count; i++)
            {
                base[i] = 0;
            }
        }

        public int Hash
        {
            get
            {
                return this.Sum();
            }
        }
    }

    public enum TUnitsOpsType
    {
        opsNone,
        opsClanHall,
        opsBooster
    }


    public enum TUnitItemType
    {
        tuiHPInc,
        tuiSpeedInc,
        tuiDamageInc,
        tuiAttackSpeedInc,
        tuiRecoverDec
    }

    public enum TSpellActionType
    {
        sarNone,
        satTornado,
        satHealingSpell,
        satRageSpell,
        satAttackFreeze
    }

    public enum TDamageType
    {
        dtNone,
        dtSingleTarget,
        dtSingleTargetShot,
        dtSplashFixedCoords,
        dtSplashUnitCoords,
        dtHeal,
        dtRemoveUnits,
        dtSplashFixedCoordsSelf
    }

    public enum FightState
    {
        Active,
        Paused,
        Ended
    }

    public enum AddActionError
    {
        FightDisposed = -2,
        NotAttacker = -1,
        Succsess = 0,
        NotImplemented,
        ItemNotFound,
        NoMoreItems,
        UnitLandingPlace,
        SpellLandingPlace,
        ItemLocked,
        UncorrectPaidItemId,
        HeroNotFound,
        HeroTargetNotFound,
        HeroTargetWasSetup
    }
}

