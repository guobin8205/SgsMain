using Common.Extensions.SpanExt;
using SgsCore.Network.ProtocolsNew;
using SgsCore.Network.ProtocolsNew.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SgsCore.Managers.Record
{
    public class RecordHead : IProtocol
    {
        public string version;
        public string tag;
        public string auth;
        public string username;
        public string serverName;
        public string gameMode;
        public string groupName;
        public string title;
        public string comment;

        public bool Decode(ReadOnlySpan<byte> buffer)
        {
            int offset = buffer.Length;
            version = buffer.MoveReadStringGBK();
            tag = buffer.MoveReadStringGBK();
            buffer.Move(4);
            int headerLen = buffer.MoveReadInt();
            auth = buffer.MoveReadStringGBK();
            username = buffer.MoveReadStringGBK();
            serverName = buffer.MoveReadStringGBK();
            gameMode = buffer.MoveReadStringGBK();
            groupName = buffer.MoveReadStringGBK();
            buffer.MoveReadBytes(100);
            buffer.MoveReadBytes(512);
            int createTime = buffer.MoveReadInt();
            int startTime = buffer.MoveReadInt();
            int endTime = buffer.MoveReadInt();
            int timeTotal = buffer.MoveReadInt();
            bool isViewer = buffer.MoveReadBool();
            bool IsMatch = buffer.MoveReadBool();
            bool IsReconnect = buffer.MoveReadBool();
            bool Completed = buffer.MoveReadBool();
            uint gameResultPosition = buffer.MoveReadUInt();
            uint gameResultJsonPosition = buffer.MoveReadUInt();
            int end = buffer.Length - offset;

            return true;
        }

        public void Encode(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }

    public class TableRule : IProtocol
    {
        public int tableId;
        public bool bDouble;
        public int randSeat;
        public bool forbidChat;
        public int gameTimer;
        public string name;
        public bool bPassword;
        public int exType;
        public bool allowView;
        public bool is1V1Ban4;

        public bool Decode(ReadOnlySpan<byte> buffer)
        {
            tableId = buffer.MoveReadInt();
            bDouble = buffer.MoveReadBool();
            randSeat = buffer.MoveReadInt();
            forbidChat = buffer.MoveReadBool();
            gameTimer = buffer.MoveReadInt();
            name = buffer.MoveReadStringGBK();
            bPassword = buffer.MoveReadBool();
            exType = buffer.MoveReadInt();
            allowView = buffer.MoveReadBool();
            is1V1Ban4 = buffer.MoveReadBool();

            return true;
        }

        public void Encode(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }

    public class TableInfo : IProtocol
    {
        public int tableId;
        public int exType;
        public bool hasPass;
        public int maxPlayer;
        public int nowPlayer;
        public bool allowViewGame;
        public int areaid;
        public int randSeat;
        public int gameTimer;
        public int minLevel;
        public int maxLevel;
        public bool forbidChat;
        public string name;
        public int seasonId;

        public bool Decode(ReadOnlySpan<byte> buffer)
        {
            tableId = buffer.MoveReadInt();
            exType = buffer.MoveReadInt();
            hasPass = buffer.MoveReadBool();
            maxPlayer = buffer.MoveReadInt();
            nowPlayer = buffer.MoveReadInt();
            allowViewGame = buffer.MoveReadBool();
            areaid = buffer.MoveReadInt();
            randSeat = buffer.MoveReadInt();
            gameTimer = buffer.MoveReadInt();
            minLevel = buffer.MoveReadInt();
            maxLevel = buffer.MoveReadInt();
            forbidChat = buffer.MoveReadBool();
            name = buffer.MoveReadStringGBK();
            randSeat = buffer.MoveReadInt();
            seasonId = buffer.MoveReadInt();

            return true;
        }

        public void Encode(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }

    public class RecordTableInfo : IProtocol
    {
        public int matchId;
        public int matchGameMode;
        public int modeId;
        public int sectionId;
        public int viewGrant;
        public bool isVip;
        public string path;
        public bool isViewer;
        public TableRule tableRule;
        public TableInfo tableInfo;
        public int playerCount;
        public Dictionary<int, UserBaseData> userDatas = new Dictionary<int, UserBaseData>();
        public int selfSeatId;

        public bool Decode(ReadOnlySpan<byte> buffer)
        {
            matchId = buffer.MoveReadInt();
            matchGameMode = buffer.MoveReadInt();
            modeId = buffer.MoveReadInt();
            sectionId = buffer.MoveReadInt();
            viewGrant = buffer.MoveReadInt();
            isVip = buffer.MoveReadBool();
            path = buffer.MoveReadStringGBK();
            isViewer = buffer.MoveReadBool();
            tableRule = new TableRule();
            tableRule.Decode(buffer);
            tableInfo = new TableInfo();
            tableInfo.Decode(buffer);
            playerCount = buffer.MoveReadInt();
            for (int i = 0; i < playerCount; i++)
            {
                int seatid = buffer.MoveReadInt();
                var udata = new UserBaseData();
                udata.Decode(buffer);
                userDatas.Add(seatid, udata);
            }
            selfSeatId = buffer.MoveReadInt();

            return true;
        }

        public void Encode(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }

    public class UserBaseData : IProtocol
    {
        public int userId;
        public string nickname;
        public int avatarShowItemId1;
        public int avatarShowItemId2;
        public int avatarShowItemId3;
        public int sex;
        public int faceId;
        public int level;
        public int winPercent;
        public int achUseId;
        public int birthDay;
        public int cityCode;
        public int lScore;
        public int nCivilContributeValue;
        public int nMiliContributeValue;
        public int nPK;
        public int vip;
        public int tongQian;
        public int wpct1v1;
        public int wpct3v3;
        public int wpctShenfen;
        public int levelPercent;
        public int friendVisible;
        public int loginProperty;
        public string avatarUrl;
        public int run1v1;
        public int run3v3;
        public int runShenfen;
        public int runCount1v1;
        public int runCount3v3;
        public int runCountShenFen;
        public bool isVipFail;
        public uint vipDays;
        public ushort generalPackage;
        public uint registerTime;
        public uint privilegedVip;
        public uint wpctGuoZhan;
        public uint runGuoZhan;
        public bool isUsedGeneralSkin;
        public uint guildId;
        public int isOlderReturn;
        public uint fightBossValue;
        public uint zhanyiValue;

        public bool Decode(ReadOnlySpan<byte> buffer)
        {
            userId = buffer.MoveReadInt();
            nickname = buffer.MoveReadStringGBK();
            avatarShowItemId1 = buffer.MoveReadInt();
            avatarShowItemId2 = buffer.MoveReadInt();
            avatarShowItemId3 = buffer.MoveReadInt();
            sex = buffer.MoveReadInt();
            faceId = buffer.MoveReadInt();
            level = buffer.MoveReadInt();
            winPercent = buffer.MoveReadInt();
            achUseId = buffer.MoveReadInt();
            birthDay = buffer.MoveReadInt();
            cityCode = buffer.MoveReadInt();
            lScore = buffer.MoveReadInt();
            nCivilContributeValue = buffer.MoveReadInt();
            nMiliContributeValue = buffer.MoveReadInt();
            nPK = buffer.MoveReadInt();
            vip = buffer.MoveReadInt();
            tongQian = buffer.MoveReadInt();
            wpct1v1 = buffer.MoveReadInt();
            wpct3v3 = buffer.MoveReadInt();
            wpctShenfen = buffer.MoveReadInt();
            levelPercent = buffer.MoveReadInt();
            friendVisible = buffer.MoveReadInt();
            loginProperty = buffer.MoveReadInt();
            avatarUrl = buffer.MoveReadStringGBK();
            run1v1 = buffer.MoveReadInt();
            run3v3 = buffer.MoveReadInt();
            runShenfen = buffer.MoveReadInt();
            runCount1v1 = buffer.MoveReadInt();
            runCount3v3 = buffer.MoveReadInt();
            runCountShenFen = buffer.MoveReadInt();
            isVipFail = buffer.MoveReadBool();
            vipDays = buffer.MoveReadUInt();
            generalPackage = buffer.MoveReadUShort();
            registerTime = buffer.MoveReadUInt();
            privilegedVip = buffer.MoveReadUInt();
            wpctGuoZhan = buffer.MoveReadUInt();
            runGuoZhan = buffer.MoveReadUInt();
            isUsedGeneralSkin = buffer.MoveReadBool();
            guildId = buffer.MoveReadUInt();
            isOlderReturn = buffer.MoveReadInt();
            fightBossValue = buffer.MoveReadUInt();
            zhanyiValue = buffer.MoveReadUInt();

            return true;
        }

        public void Encode(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RecordDataHeader
    {
        public int time;
        public int tag;
        public int id;
        public int ext;
        public int version;
        public int length;
    }

    public class RecordData : IProtocol
    {
        public RecordHead header;
        public RecordTableInfo tableInfo;
        public bool Decode(ReadOnlySpan<byte> buffer)
        {
            header = new RecordHead();
            header.Decode(buffer);
            tableInfo = new RecordTableInfo();
            tableInfo.Decode(buffer);
            while (buffer.Length > 0)
            {
                RecordDataHeader ph = buffer.MoveReadStruct<RecordDataHeader>();
                ReadOnlySpan<byte> data = buffer.Slice(0, ph.length);
                if(ph.id == 21209)
                {
                    PubGsCMoveCard mc = new PubGsCMoveCard();
                    mc.Decode(data);
                }
                buffer.Move(ph.length);
                Console.WriteLine(ph.id);
            }

            return true;
        }

        public void Encode(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
    }
}
