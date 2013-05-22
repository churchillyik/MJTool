using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MJTool
{
	public partial class QueryManager
	{
		static string gUnpackFilePath = @"AMFData\database.unpack";
		public static GameDatabase gGameDB = new GameDatabase();
		public void PrintGameDB()
		{
			if (!File.Exists(gUnpackFilePath))
			{
				DebugLog("找不到amf表" + gUnpackFilePath);
				return;
			}
			byte[] bs_f = File.ReadAllBytes(gUnpackFilePath);
			Dictionary<string, object> root = AMF_Deserializer<Dictionary<string, object>>(bs_f, bs_f.Length);
			
			if (!Directory.Exists("Database"))
			{
				Directory.CreateDirectory("Database");
			}
			
			StringBuilder sb = new StringBuilder();
			int cnt = 1;
			foreach (KeyValuePair<string, object> pair in root)
			{
				if (pair.Value.GetType().Name == "ASObject")
				{
					Dictionary<string, object> sub_dic = (Dictionary<string, object>) pair.Value;
					cnt = 0;
					sb.AppendLine(pair.Key + " 字段数：" + sub_dic.Count);
					foreach (KeyValuePair<string, object> sub_pair in sub_dic)
					{
						if (sub_pair.Value == null)
						{
							sb.AppendLine(cnt.ToString() + " ### " +  sub_pair.Key + " => null");
						}
						else
						{
							sb.AppendLine(cnt.ToString() + " ### " +  sub_pair.Key + " => " + sub_pair.Value);
						}
						cnt++;
					}
				}
				else if (pair.Value.GetType().IsArray)
				{
					object[] obj_arr = (object[]) pair.Value;
					cnt = 0;
					foreach (object obj in obj_arr)
					{
						if (obj.GetType().Name == "ASObject")
						{
							Dictionary<string, object> sub_dic = (Dictionary<string, object>) obj;
							if (cnt == 0)
							{
								foreach(string key in sub_dic.Keys)
								{
									sb.Append(key + "\t");
								}
								sb.Append("\r\n");
							}
							foreach (KeyValuePair<string, object> sub_pair in sub_dic)
							{
								if (sub_pair.Value == null)
								{
									sb.Append("\t");
								}
								else
								{
									sb.Append(sub_pair.Value.ToString() + "\t");
								}
							}
							sb.Append("\r\n");
							cnt++;
						}
						else
						{
							sb.AppendLine(obj.GetType().Name);
							DebugLog(pair.Key + "为复合表");
							break;
						}
					}
				}

				WriteLog(@"Database\" + pair.Key, sb.ToString());
				sb.Remove(0, sb.Length);
			}
			DebugLog("解析数据包完成");
		}
		
		private void init_db()
		{
			if (!File.Exists(gUnpackFilePath))
			{
				DebugLog("找不到amf表" + gUnpackFilePath);
				return;
			}
			byte[] bs_f = File.ReadAllBytes(gUnpackFilePath);
			Dictionary<string, object> root = AMF_Deserializer<Dictionary<string, object>>(bs_f, bs_f.Length);
			SetArrayObjects(root, "general", gGameDB.general);
		}
	}
	
	public class GameDatabase
	{
		public List<DBGeneral> general = new List<DBGeneral>();
	}
	
	public class DBGeneral
	{
		public int metier;
		public int nClass;
		public int agile;
		public int fSkill;
		public int dot;
		public int kickoutSoul;
		public int rSkill;
		public int id;
		public int rela3;
		public int level;
		public int limitBreak;
		public int nGet;
		public int pSkill3;
		public int slot;
		public int power;
		public int endurance;
		public int mob;
		public string icon;
		public int fightPropsBuffId;
		public int nextStarId;
		public int iSkill;
		public int movie;
		public int cumCoefficient;
		public string name;
		public int skillpgo;
		public int star;
		public int employSoul;
		public int ndot;
		public int rela1;
		public int blew;
		public int pSkill2;
		public int cumulation;
		public int hp;
		public int rela2;
		public int world;
		public int soul;
		public int voice;
		public int type;
		public int image;
		public int price;
		public int sex;
		public int pSkill1;
		public int mentality;
	}
}
