using System.Collections.Generic;
using EnhancedMap.Core.MapObjects;

namespace EnhancedMap.Core
{
    public class GameHouse
    {
        public uint ID;
        public Position Size;

        public GameHouse(uint id, Position size)
        {
            ID = id;
            Size = size;
        }

        public GameHouse(uint id, short w, short h) : this(id, new Position(w, h))
        {
        }
    }

    public static class HouseReader
    {
        private const string GAME_HOUSES_XML = "gamehouses.xml";

        private static readonly Dictionary<uint, GameHouse> _gameHouses = new Dictionary<uint, GameHouse>
        {
            // prefabric
            {0x64, new GameHouse(0x64, 8, 8)},
            {0x65, new GameHouse(0x65, 8, 8)},
            {0x66, new GameHouse(0x66, 8, 8)},
            {0x67, new GameHouse(0x67, 8, 8)},
            {0x68, new GameHouse(0x68, 8, 8)},
            {0x69, new GameHouse(0x69, 8, 8)},
            {0x6A, new GameHouse(0x6A, 8, 8)},
            {0x6B, new GameHouse(0x6B, 8, 8)},
            {0x6C, new GameHouse(0x6C, 8, 8)},
            {0x6D, new GameHouse(0x6D, 8, 8)},
            {0x6E, new GameHouse(0x6E, 8, 8)},
            {0x6F, new GameHouse(0x6F, 8, 8)},
            {0x70, new GameHouse(0x70, 8, 8)},
            {0x71, new GameHouse(0x71, 8, 8)},
            {0x72, new GameHouse(0x72, 8, 8)},
            {0x73, new GameHouse(0x73, 8, 8)},
            {0x74, new GameHouse(0x74, 15, 15)},
            {0x75, new GameHouse(0x75, 15, 15)},
            {0x76, new GameHouse(0x76, 15, 15)},
            {0x77, new GameHouse(0x77, 15, 15)},
            {0x78, new GameHouse(0x78, 15, 15)},
            {0x79, new GameHouse(0x79, 15, 15)},
            {0x7A, new GameHouse(0x7A, 24, 16)},
            {0x7B, new GameHouse(0x7B, 24, 16)},
            {0x7C, new GameHouse(0x7C, 24, 24)},
            {0x7D, new GameHouse(0x7D, 24, 24)},
            {0x7E, new GameHouse(0x7E, 31, 32)},
            {0x7F, new GameHouse(0x7F, 31, 32)},
            {0x87, new GameHouse(0x87, 16, 15)},
            {0x8C, new GameHouse(0x8C, 16, 15)},
            {0x8D, new GameHouse(0x8D, 16, 15)},
            {0x96, new GameHouse(0x96, 15, 15)},
            {0x98, new GameHouse(0x98, 8, 8)},
            {0x9A, new GameHouse(0x9A, 8, 14)},
            {0x9C, new GameHouse(0x9C, 12, 10)},
            {0x9E, new GameHouse(0x9E, 12, 12)},
            {0xA0, new GameHouse(0xA0, 8, 8)},
            {0xA2, new GameHouse(0xA2, 7, 8)},

            //E4 Cambrian Villa w/ Balcony 13, 10
            {0xE4, new GameHouse(0xE4, 13, 10) },
            //F3 Palisade Fortress
            {0xF3, new GameHouse(0xF3, 27, 24) },
            //10D Andarian Two Story 10, 12
            {0x10D, new GameHouse(0x10D, 10, 12) },
            //16B Norse Small House 7, 8
            {0x16B, new GameHouse(0x16B, 10, 12) },
            //180 Grand Fortress 37, 35
            {0x180, new GameHouse(0x180, 37, 35) },
            //10F Fieldstone and Plaster Shoppe 9, 7
            {0x10F, new GameHouse(0x10F, 9, 7) },
            //137 Stone Square House 9, 8
            {0x137, new GameHouse(0x137, 9, 8) },
            //16D Norse Watchtower 10, 10
            {0x16D, new GameHouse(0x16D, 10, 10) },
            //107 Fieldstone and Plaster Courtyard 19, 18
            {0x107, new GameHouse(0x107, 19, 18) },
            //17B  Limestone Fortress 21, 15
            {0x17B, new GameHouse(0x17B, 21, 15) },
            //198 Rural Courtyard 17, 16
            {0x198, new GameHouse(0x198, 17, 16) },
            //E1 Cambrian Sandstone Cellar 7, 10
            {0xE1, new GameHouse(0xE1, 7, 10) },
            //17C Knights Tower 12, 11
            {0x17C, new GameHouse(0x17C, 12, 11) },
            //120 Andarian Mercantile Guildhouse 16, 11
            {0x120, new GameHouse(0x120, 16, 11) },
            //16C Norse Grand Lodge 26, 25
            {0x16C, new GameHouse(0x16C, 26, 25) },         //FIX GEOMETRY
            //19E Light Brick and White Wash Two Story East
            {0x19E, new GameHouse(0x19E, 17, 9) },
            //17D Limestone Small House 8,7
            {0x17D, new GameHouse(0x17D, 8, 7) },
            //FD Stone Shoppe 10, 10
            {0xFD, new GameHouse(0xFD, 10, 10) },
            //FC Medium Stone Tower East 13, 10
            {0xFC, new GameHouse(0xFC, 13, 10) },
            //FB Medium Stone Tower 12, 14
            {0xFB, new GameHouse(0xFB, 12, 14) },
            //13E Andarian Block House 11, 9
            {0x13E, new GameHouse(0x13E, 11, 9) },
            //170 Lightstone and Wood Villa 14, 17
            {0x170, new GameHouse(0x170, 14, 17) },
            //173 Lightstone and Plaster Small House 7, 8
            {0x173, new GameHouse(0x173, 7, 8) },
            //176 Lightstone Beamed Villa 11, 10
            {0x176, new GameHouse(0x176, 11, 10) },
            //181 Grand Keep 29, 29
            {0x181, new GameHouse(0x181, 29, 29) },
            //141 Small Andarian Stone House 7, 8
            {0x141, new GameHouse(0x141, 7, 8) },
            //133 Small Andarian Stone House east 8, 7
            {0x133, new GameHouse(0x133, 8, 7) },
            //D4 Blue Stone Guild Fortress 31, 32
            {0xD4, new GameHouse(0xD4, 31, 32) },
            //150 Andarian Bluestone and Slate 10, 12
            {0x150, new GameHouse(0x150, 10, 12) },
            //DE Sandstone Chateau 19, 17
            {0xDE, new GameHouse(0xDE, 19, 17) },
            //17E Limestone Keep 21, 22
            {0x17E, new GameHouse(0x17E, 21, 22) },
            //10C Andarian Merchants Villa 13, 11
            {0x10C, new GameHouse(0x10C, 13, 11) },
            //122 Small Wooden Houseboat 9, 6
            {0x122, new GameHouse(0x122, 9, 6) },
            //112 Guild Fortress 26, 28
            {0x112, new GameHouse(0x112, 26, 28) },
            //119 Rural Villa 10, 8
            {0x119, new GameHouse(0x119, 10, 8) },
            //DD Marble Redoubt 9, 10
            {0xDD, new GameHouse(0xDD, 9, 10) },
            //EA Square Stone Keep 14, 15
            {0xEA, new GameHouse(0xEA, 14, 15) },
            //167 Norse Great Lodge 12, 16
            {0x167, new GameHouse(0x167, 12, 16) },
            //182 gatehouse 25, 9
            {0x182, new GameHouse(0x182, 25, 9) },
            //12E Small Red Brick House 8, 7
            {0x12E, new GameHouse(0x12E, 8, 7) },
            //13F Stone Square House 9, 8
            {0x13F, new GameHouse(0x13F, 9, 8) },
            //13A Andarian Sloped Roof Lightstone and Plaster 11, 14
            {0x13A, new GameHouse(0x13A, 11, 14) },
            //12A Shingled Two Story Boathouse 23, 9
            {0x12A, new GameHouse(0x12A, 23, 9) },
            //169 Norse Longhouse 21, 13
            {0x169, new GameHouse(0x169, 21, 13) },
            //19B Light Brick and Whitewash Two Story Adobe 17, 17
            {0x19B, new GameHouse(0x19B, 17, 17) },
            //12F Small Shingled House 8,7
            {0x12F, new GameHouse(0x12F, 8, 7) },
            //174 Lightstone and Wood Loft 12, 14
            {0x174, new GameHouse(0x174, 12, 14) },
            //140 Windmill House 9, 7
            {0x140, new GameHouse(0x140, 9, 7) },
            //19C Light Brick and Whitewash Two Story South 9, 17
            {0x19C, new GameHouse(0x19C, 9, 17) },
            //14C Brick And Plaster Square House 8, 9
            {0x14C, new GameHouse(0x14C, 8, 9) },
            //179 Limestone and Plaster Redoubt 15, 15
            {0x179, new GameHouse(0x179, 15, 15) },
            //FE Landaus Lodge 14, 20
            {0xFE, new GameHouse(0xFE, 14, 20) },
            //19D Light Brick and Whitewash Ranch Courtyard 29, 19
            {0x19D, new GameHouse(0x19D, 29, 19) },
            //17F Limestone Mercantile Tower 8, 15
            {0x17F, new GameHouse(0x17F, 8, 15) },
            //110 Andarian Barn 9, 11
            {0x110, new GameHouse(0x110, 9, 11) },
            //104 Palisade Blockhouse 9, 8
            {0x104, new GameHouse(0x104, 9, 8) },
            //F2 Palisade Scout Tower 8, 9
            {0xF2, new GameHouse(0xF2, 8, 9) },
            //155 Andarian Courtyard Keep 31, 33
            {0x155, new GameHouse(0x155, 31, 33) },
            //13B Spired Slate and Plaster Two Story House 11, 9
            {0x13B, new GameHouse(0x13B, 11, 9) },
            //D2 Andarian Farmstead 30, 30
            {0xD2, new GameHouse(0xD2, 30, 30) },
            //100 Lightstone Juliet House 9, 14
            {0x100, new GameHouse(0x100, 9, 14) },
            //DC Desert Tower 10, 9
            {0xDC, new GameHouse(0xDC, 10, 9) },
            //DF Cambrian Farmstead 17, 16
            {0xDF, new GameHouse(0xDF, 17, 16) },
            //103 Farmlands Two Story Ranch House 13, 12
            {0x103, new GameHouse(0x103, 13, 12) },
            //117 Prevalian Manor 22, 25
            {0x117, new GameHouse(0x117, 22, 25) },
            //171 Lightstone and Wood Villa with Tower 17, 15
            {0x171, new GameHouse(0x171, 17, 15) },
            //130 Mage's Tower 12, 13
            {0x130, new GameHouse(0x130, 12, 13) },
            //114 Frontier Veranda House
            {0x114, new GameHouse(0x114, 16, 18) },
            //16A Norse Great Hall
            {0x16A, new GameHouse(0x16A, 21, 17) },
            //14E Light Brick and Whitewash Villa
            {0x14E, new GameHouse(0x14E, 12, 16) },
            //136 Frontier Slate Roof Cabin 12, 14
            {0x136, new GameHouse(0x136, 12, 14) },
            //121 Small Wooden Houseboat East 6, 9
            {0x121, new GameHouse(0x121, 6, 9) },
            //109 Farmlands Cabin With Cellar 16, 7
            {0x109, new GameHouse(0x109, 16, 7) },
            //175 Shutter Cottage 11, 8
            {0x175, new GameHouse(0x175, 11, 8) },
            //10A Guesthouse 27, 13
            {0x10A, new GameHouse(0x10A, 27, 13) },
            //14D Small Brick And Plaster 8, 7
            {0x14D, new GameHouse(0x14D, 8, 7) },
            //11B Rural Shoppe 8, 11
            {0x11B, new GameHouse(0x11B, 8, 11) },
            //142 Small Log House 8, 7
            {0x142, new GameHouse(0x142, 8, 7) },
            //148 Andarian Villa 16, 20
            {0x148, new GameHouse(0x148, 16, 20) },
            //144 Frontier Log House 12, 12
            {0x144, new GameHouse(0x144, 12, 12) },
            //108 Farmlands Ranch House 9, 10
            {0x108, new GameHouse(0x108, 9, 10) },
            //14F Small Andarian Blockhouse 8, 9
            {0x14F, new GameHouse(0x14F, 8, 9) },
            //12D Red Brick Square House 8, 8
            {0x12D, new GameHouse(0x12D, 8, 8) },
            //187 Shingled Two Story Houseboat South 9, 23
            {0x187, new GameHouse(0x187, 9, 23) },
            //F1 Palisade Outpost 18, 12
            {0xF1, new GameHouse(0xF1, 18, 12) },
            //118 Rural Cottage 10, 8
            {0x118, new GameHouse(0x118, 10, 8) },
            //145 Frontier Log and Slate Overlook 13, 14
            {0x145, new GameHouse(0x145, 13, 14) },
            //11D Andarian Residence 10, 12
            {0x11D, new GameHouse(0x11D, 10, 12) },
            //147 Rural Barn 18, 12
            {0x147, new GameHouse(0x147, 18, 12) },
            //F4 Cambrian Pillared Manor 20, 13
            {0xF4, new GameHouse(0xF4, 20, 13) },
            //146 Frontier Guildhouse 27, 25
            {0x146, new GameHouse(0x146, 27, 25) },
            //E8 Lightstone And Slate Compound 31, 31
            {0xE8, new GameHouse(0xE8, 31, 31) },
            //132 Sandstone And Shingle Square House 8, 8
            {0x132, new GameHouse(0x132, 8, 8) },
            //102 Large Frontier House 17, 15
            {0x102, new GameHouse(0x102, 17, 15) },
            //115 Lightstone Small Fortress 10, 10
            {0x115, new GameHouse(0x115, 10, 10) },
            //ED Woodsman's Lodge 13, 13
            {0xED, new GameHouse(0xED, 13, 13) },
            //165 Norse Farmstead 18, 21
            {0x165, new GameHouse(0x165, 18, 21) },
            //11E Andarian Abode 10, 15
            {0x11E, new GameHouse(0x11E, 10, 15) },
            //111 Andarian Merchant's Residence 10, 12
            {0x111, new GameHouse(0x111, 10, 12) },
            //149 Andarian Villa With Tower 18, 23
            {0x149, new GameHouse(0x149, 18, 23) },
            //EC Stone Barracks 14, 15
            {0xEC, new GameHouse(0xEC, 14, 15) },
            //139 Frontier Residence 13, 14
            {0x139, new GameHouse(0x139, 13, 14) },
            //D8 Sandstone Redoubt 11, 12
            {0xD8, new GameHouse(0xD8, 11, 12) },
            //D6 Large Sandstone Compound 32, 33
            {0xD6, new GameHouse(0xD6, 32, 33) },
            //184 Compact Wooden Houseboat East 8, 14
            {0x184, new GameHouse(0x184, 8, 14) },
            //113 Prevalian Fortress 31, 30
            {0x113, new GameHouse(0x113, 31, 30) },
            //105 Wooden Lookout 6, 7
            {0x105, new GameHouse(0x105, 6, 7) },
            //17A Limestone and Plaster Lookout 8, 9
            {0x17A, new GameHouse(0x17A, 8, 9) },
            //116 Prevalian Redoubt 13, 16
            {0x116, new GameHouse(0x116, 13, 16) },
            //19A Light Brick and Whitewash Lookout 9, 10
            {0x19A, new GameHouse(0x19A, 9, 10) },
            //E9 Compact Stone Keep 20, 22
            {0xE9, new GameHouse(0xE9, 20, 22) },
            //154 Caravan Wagon East 5, 8
            {0x154, new GameHouse(0x154, 5, 8) },
            //153 Caravan Wagon South 8, 5
            {0x153, new GameHouse(0x153, 8, 5) },
            //16E Lightstone Mansion 17, 17
            {0x16E, new GameHouse(0x16E, 17, 17) },
            //10E Andarian Two Story Porch Ranch House 15, 17
            {0x10E, new GameHouse(0x10E, 15, 17) },
            //166 Norse Chalet 17, 16
            {0x166, new GameHouse(0x166, 17, 16) },
            //FF Lightstone Fortress 14, 15
            {0xFF, new GameHouse(0xFF, 14, 15) },
            //F0 Palisade Keep 18, 12
            {0xF0, new GameHouse(0xF0, 18, 12) },
            //E5 Cambrian Residence With Balcony 14, 10
            {0xE5, new GameHouse(0xE5, 14, 10) },
            //EF Palisade Tower 10, 9
            {0xEF, new GameHouse(0xEF, 10, 9) },
            //134 Small Lightstone House 8, 7
            {0x134, new GameHouse(0x134, 8, 7) },
            //F8 Andarian Veranda East 11, 10
            {0xF8, new GameHouse(0xF8, 11, 10) },
            //128 Wooden Houseboat east 10, 18
            {0x128, new GameHouse(0x128, 10, 18) },
            //124 Fieldstone And Plaster Square House 8, 8
            {0x124, new GameHouse(0x124, 8, 8) },
            //135 Small Frontier Cabin 11, 10
            {0x135, new GameHouse(0x135, 11, 10) },
            //199 Light Brick and Whitewash Adobe 17, 17
            {0x199, new GameHouse(0x199, 17, 17) },
            //DA Cambrian Large House 14, 13
            {0xDA, new GameHouse(0xDA, 14, 13) },
            //125 Red Brick Steeple 13, 13
            {0x125, new GameHouse(0x125, 13, 13) },
            //EB Large tower 16, 15
            {0xEB, new GameHouse(0xEB, 16, 15) },
            //143 Frontier Shoppe 12, 9
            {0x143, new GameHouse(0x143, 12, 9) },
            //101 Lightstone Patio House 15, 16
            {0x101, new GameHouse(0x101, 15, 16) },
            //11A Rural Courtyard Shoppe 17, 16
            {0x11A, new GameHouse(0x11A, 17, 16) },
            //F7 Andarian Two Story Brick and Plaster 16, 15
            {0xF7, new GameHouse(0xF7, 16, 15) },
            //12C Wooden Square House 8, 8
            {0x12C, new GameHouse(0x12C, 8, 8) },
            //{0x12C, new GameHouse(0x12C, 8, 8) },

            //10 BOAT!?!?! 5, 13
            {0x10, new GameHouse(0x10, 5, 13) },


            //18E Syn Guildhouse 30, 30
            {0x18E, new GameHouse(0x18E, 30, 30) },


            // foundations
            {0x13EC, new GameHouse(0x13EC, 7, 7)},
            {0x13ED, new GameHouse(0x13ED, 7, 8)},
            {0x13EE, new GameHouse(0x13EE, 7, 9)},
            {0x13EF, new GameHouse(0x13EF, 7, 10)},
            {0x13F0, new GameHouse(0x13F0, 7, 11)},
            {0x13F1, new GameHouse(0x13F1, 7, 12)},
            {0x13F8, new GameHouse(0x13F8, 8, 7)},
            {0x13F9, new GameHouse(0x13F9, 8, 8)},
            {0x13FA, new GameHouse(0x13FA, 8, 9)},
            {0x13FB, new GameHouse(0x13FB, 8, 10)},
            {0x13FC, new GameHouse(0x13FC, 8, 11)},
            {0x13FD, new GameHouse(0x13FD, 8, 12)},
            {0x13FE, new GameHouse(0x13FE, 8, 13)},
            {0x1404, new GameHouse(0x1404, 9, 7)},
            {0x1405, new GameHouse(0x1405, 9, 8)},
            {0x1406, new GameHouse(0x1406, 9, 9)},
            {0x1407, new GameHouse(0x1407, 9, 10)},
            {0x1408, new GameHouse(0x1408, 9, 11)},
            {0x1409, new GameHouse(0x1409, 9, 12)},
            {0x140A, new GameHouse(0x140A, 9, 13)},
            {0x140B, new GameHouse(0x140B, 9, 14)},
            {0x1410, new GameHouse(0x1410, 10, 7)},
            {0x1411, new GameHouse(0x1411, 10, 8)},
            {0x1412, new GameHouse(0x1412, 10, 9)},
            {0x1413, new GameHouse(0x1413, 10, 10)},
            {0x1414, new GameHouse(0x1414, 10, 11)},
            {0x1415, new GameHouse(0x1415, 10, 12)},
            {0x1416, new GameHouse(0x1416, 10, 13)},
            {0x1417, new GameHouse(0x1417, 10, 14)},
            {0x1418, new GameHouse(0x1418, 10, 15)},
            {0x141C, new GameHouse(0x141C, 11, 7)},
            {0x141D, new GameHouse(0x141D, 11, 8)},
            {0x141E, new GameHouse(0x141E, 11, 9)},
            {0x141F, new GameHouse(0x141F, 11, 10)},
            {0x1420, new GameHouse(0x1420, 11, 11)},
            {0x1421, new GameHouse(0x1421, 11, 12)},
            {0x1422, new GameHouse(0x1422, 11, 13)},
            {0x1423, new GameHouse(0x1423, 11, 14)},
            {0x1424, new GameHouse(0x1424, 11, 15)},
            {0x1425, new GameHouse(0x1425, 11, 16)},
            {0x1428, new GameHouse(0x1428, 12, 7)},
            {0x1429, new GameHouse(0x1429, 12, 8)},
            {0x142A, new GameHouse(0x142A, 12, 9)},
            {0x142B, new GameHouse(0x142B, 12, 10)},
            {0x142C, new GameHouse(0x142C, 12, 11)},
            {0x142D, new GameHouse(0x142D, 12, 12)},
            {0x142E, new GameHouse(0x142E, 12, 13)},
            {0x142F, new GameHouse(0x142F, 12, 14)},
            {0x1430, new GameHouse(0x1430, 12, 15)},
            {0x1431, new GameHouse(0x1431, 12, 16)},
            {0x1432, new GameHouse(0x1432, 12, 17)},
            {0x1435, new GameHouse(0x1435, 13, 8)},
            {0x1436, new GameHouse(0x1436, 13, 9)},
            {0x1437, new GameHouse(0x1437, 13, 10)},
            {0x1438, new GameHouse(0x1438, 13, 11)},
            {0x1439, new GameHouse(0x1439, 13, 12)},
            {0x143A, new GameHouse(0x143A, 13, 13)},
            {0x143B, new GameHouse(0x143B, 13, 14)},
            {0x143C, new GameHouse(0x143C, 13, 15)},
            {0x143D, new GameHouse(0x143D, 13, 16)},
            {0x143E, new GameHouse(0x143E, 13, 17)},
            {0x143F, new GameHouse(0x143F, 13, 18)},
            {0x1442, new GameHouse(0x1442, 14, 9)},
            {0x1443, new GameHouse(0x1443, 14, 10)},
            {0x1444, new GameHouse(0x1444, 14, 11)},
            {0x1445, new GameHouse(0x1445, 14, 12)},
            {0x1446, new GameHouse(0x1446, 14, 13)},
            {0x1447, new GameHouse(0x1447, 14, 14)},
            {0x1448, new GameHouse(0x1448, 14, 15)},
            {0x1449, new GameHouse(0x1449, 14, 16)},
            {0x144A, new GameHouse(0x144A, 14, 17)},
            {0x144B, new GameHouse(0x144B, 14, 18)},
            {0x144F, new GameHouse(0x144F, 15, 10)},
            {0x1450, new GameHouse(0x1450, 15, 11)},
            {0x1451, new GameHouse(0x1451, 15, 12)},
            {0x1452, new GameHouse(0x1452, 15, 13)},
            {0x1453, new GameHouse(0x1453, 15, 14)},
            {0x1454, new GameHouse(0x1454, 15, 15)},
            {0x1455, new GameHouse(0x1455, 15, 16)},
            {0x1456, new GameHouse(0x1456, 15, 17)},
            {0x1457, new GameHouse(0x1457, 15, 18)},
            {0x145C, new GameHouse(0x145C, 16, 11)},
            {0x145D, new GameHouse(0x145D, 16, 12)},
            {0x145E, new GameHouse(0x145E, 16, 13)},
            {0x145F, new GameHouse(0x145F, 16, 14)},
            {0x1460, new GameHouse(0x1460, 16, 15)},
            {0x1461, new GameHouse(0x1461, 16, 16)},
            {0x1462, new GameHouse(0x1462, 16, 17)},
            {0x1463, new GameHouse(0x1463, 16, 18)},
            {0x1469, new GameHouse(0x1469, 17, 12)},
            {0x146A, new GameHouse(0x146A, 17, 13)},
            {0x146B, new GameHouse(0x146B, 17, 14)},
            {0x146C, new GameHouse(0x146C, 17, 15)},
            {0x146D, new GameHouse(0x146D, 17, 16)},
            {0x146E, new GameHouse(0x146E, 17, 17)},
            {0x146F, new GameHouse(0x146F, 17, 18)},
            {0x1476, new GameHouse(0x1476, 18, 13)},
            {0x1477, new GameHouse(0x1477, 18, 14)},
            {0x1478, new GameHouse(0x1478, 18, 15)},
            {0x1479, new GameHouse(0x1479, 18, 16)},
            {0x147A, new GameHouse(0x147A, 18, 17)},
            {0x147B, new GameHouse(0x147B, 18, 18)}
        };

        public static GameHouse GetHouse(uint id)
        {
            _gameHouses.TryGetValue(id, out GameHouse house);
            return house;
        }

        public static void SaveXml()
        {
            /*XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t"
            };
            using (XmlWriter xml = XmlWriter.Create(GAME_HOUSES_XML, settings))
            {
                xml.WriteStartDocument(true);
                xml.WriteStartElement("gamehouses");

                foreach (GameHouse house in _gameHouses.Values.ToList())
                {
                    xml.WriteStartElement("house");
                    xml.WriteAttributeString("id", "0x" + house.ID.ToString("X"));
                    xml.WriteAttributeString("w", house.Size.X.ToString());
                    xml.WriteAttributeString("h", house.Size.Y.ToString());
                    xml.WriteEndElement();
                }

                xml.WriteEndElement();
            }*/
        }

        public static void LoadXml()
        {
            /*if (!File.Exists(GAME_HOUSES_XML))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(GAME_HOUSES_XML);
            XmlElement root = doc["gamehouses"];
            foreach (XmlElement e in root)
            {
                GameHouse house = new GameHouse(uint.Parse(e.ToText("id").Remove(0, 2), System.Globalization.NumberStyles.HexNumber), e.ToText("w").ToShort(), e.ToText("h").ToShort());
                _gameHouses[house.ID] = house;
            }*/
        }
    }
}