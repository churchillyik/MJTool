using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

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
							int idx = 1;
							if (cnt == 0)
							{
								foreach(string key in sub_dic.Keys)
								{
									if (idx == sub_dic.Count)
									{
										sb.Append(key + "\r\n");
									}
									else
									{
										sb.Append(key + "\t");
									}
									idx++;
								}
							}
							idx = 1;
							foreach (KeyValuePair<string, object> sub_pair in sub_dic)
							{
								if (idx == sub_dic.Count)
								{
									if (sub_pair.Value == null)
									{
										sb.Append("\r\n");
									}
									else
									{
										sb.Append(sub_pair.Value.ToString() + "\r\n");
									}
								}
								else
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
								idx++;
							}
							
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
			LoadTable(gGameDB.general, @"Database\general");
		}
		
		private void LoadTable<T>(List<T> lst_objs, string file_path) where T : new()
		{
			if (!File.Exists(file_path))
			{
				DebugLog("找不到数据表" + file_path);
				return;
			}
			
			lst_objs.Clear();
			string[] lines = File.ReadAllLines(file_path);
			for (int i = 1; i < lines.Length; i++)
			{
				string[] fields = lines[i].Split(new char[]{'\t'});
				T t_obj = new T();
				FieldInfo[] field_info = t_obj.GetType().GetFields();
				if (fields.Length != field_info.Length)
				{
					DebugLog("数据表" + file_path + "的第" + i + "行与数据结构字段数不匹配！");
					break;
				}
				for (int j = 1; j < field_info.Length; j++)
				{
					try
					{
						if (field_info[j].FieldType.Name == "Int32")
						{
							field_info[j].SetValue(t_obj, Convert.ToInt32(fields[j]));
						}
						else if (field_info[j].FieldType.Name == "Int64")
						{
							field_info[j].SetValue(t_obj, Convert.ToInt64(fields[j]));
						}
						else if (field_info[j].FieldType.Name == "Double")
						{
							field_info[j].SetValue(t_obj, Convert.ToDouble(fields[j]));
						}
						else if (field_info[j].FieldType.Name == "String")
						{
							field_info[j].SetValue(t_obj, Convert.ToString(fields[j]));
						}
						else if (field_info[j].FieldType.Name == "Boolean")
						{
							field_info[j].SetValue(t_obj, Convert.ToBoolean(fields[j]));
						}
						else
						{
							DebugLog("无法设定" + field_info[j].FieldType.Name + "类型的数据");
						}
					}
					catch (FormatException)
					{
						DebugLog("无法把表[" + file_path + "]的[" + field_info[j].Name + "]字段转化为成员变量值");
					}
					catch (Exception e)
					{
						DebugLog(e.StackTrace);
					}
				}
				lst_objs.Add(t_obj);
			}
		}
	}
	
	public class GameDatabase
	{
		public List<DBGeneral> general = new List<DBGeneral>();
		
		public DBGeneral GetGeneralByID(int id)
		{
			foreach (DBGeneral gen in general)
			{
				if (gen.id == id)
				{
					return gen;
				}
			}
			return null;
		}
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
