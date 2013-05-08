using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluorineFx.AMF3;

namespace MJTool
{
	public partial class QueryManager
	{
		private static Dictionary<CmdIDs, UserCommand> gDicCmd = new Dictionary<CmdIDs, UserCommand>();
		private void init_cmd()
		{
			gDicCmd.Add(CmdIDs.USER_GET_INFO, new UserCommand(
				"User.getInfo", 
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.SESSION_KEY)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
			
			gDicCmd.Add(CmdIDs.USER_GET_GIFT, new UserCommand(
				"User.getGift", 
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.SINGLE)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
			
			gDicCmd.Add(CmdIDs.USER_GET_MESSAGE, new UserCommand(
				"User.getMessage", 
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.SINGLE)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
			
			gDicCmd.Add(CmdIDs.FEED_MSG_BOX, new UserCommand(
				"Feed.msgBox", 
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.SINGLE)|
				((ulong)1<<(int)CmdParam.FINISH_GUIDE)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
			
			gDicCmd.Add(CmdIDs.USER_GET_LOGIN_AWARD, new UserCommand(
				"User.getLoginAward", 
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.SINGLE)|
				((ulong)1<<(int)CmdParam.FINISH_GUIDE)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
			
			gDicCmd.Add(CmdIDs.USER_GET_LUCK_INFO, new UserCommand(
				"User.getLuckInfo", 
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.SINGLE)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
			
			gDicCmd.Add(CmdIDs.USER_REFRESH_GENERAL, new UserCommand(
				"User.refreshGeneral", 
				((ulong)1<<(int)CmdParam.TYPE)|
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.SINGLE)|
				((ulong)1<<(int)CmdParam.FINISH_GUIDE)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
			
			gDicCmd.Add(CmdIDs.USER_EMPLOY_GENERAL, new UserCommand(
				"User.employGeneral", 
				((ulong)1<<(int)CmdParam.GENERAL_ID)|
				((ulong)1<<(int)CmdParam.CT)|
				((ulong)1<<(int)CmdParam.VERSION)|
				((ulong)1<<(int)CmdParam.CLIENT_TIME)|
				((ulong)1<<(int)CmdParam.SINGLE)|
				((ulong)1<<(int)CmdParam.FINISH_GUIDE)|
				((ulong)1<<(int)CmdParam.SOUL)|
				((ulong)1<<(int)CmdParam.IS_AMF)
			));
		}
		
		public void doUserCommand(object o)
		{
			CmdArg cmd_arg = (CmdArg) o;
			if (cmd_arg == null)
			{
				return;
			}
			CmdIDs id = cmd_arg.cmd_id;
			User curUser = cmd_arg.cur_user;
			
			if (!gDicCmd.ContainsKey(id))
			{
				DebugLog("未初始化的命令ID - " + id.ToString());
				return;
			}
			UserCommand usr_cmd = gDicCmd[id];
			Dictionary<string, object> dic_pck = new Dictionary<string, object>();
			
			// type => <int>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.TYPE)) != (ulong)0)
			{
				int nType = 0;
				if (o is RfsGenCmdArg)
				{
					RfsGenCmdArg arg = (RfsGenCmdArg)o;
					nType = arg.nType;
				}
				else
				{
					DebugLog("错误地使用了命令参数[TYPE]");
					return;
				}
				dic_pck.Add("type", nType);
			}
			
			// generalId => <int>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.GENERAL_ID)) != (ulong)0)
			{
				EplGenCmdArg arg = (EplGenCmdArg) o;
				if (arg == null)
				{
					DebugLog("错误地使用了命令参数[TYPE]");
					return;
				}
				dic_pck.Add("generalId", arg.nGenID);
			}
			
			// ct => <double>ms
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.CT)) != (ulong)0)
			{
				double ct = (double)UnixTimeStamp(DateTime.Now);
				dic_pck.Add("ct", ct);
			}
			
			// version => <string>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.VERSION)) != (ulong)0)
			{
				dic_pck.Add("version", ServerParam.strVersion);
			}
			
			// sessionkey => <string>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.SESSION_KEY)) != (ulong)0)
			{
				dic_pck.Add("sessionkey", this.MakeSessionKey(curUser));
			}
			
			// clientTime => <double> s
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.CLIENT_TIME)) != (ulong)0)
			{
				double cl_tm = (double)(UnixTimeStamp(DateTime.Now) / 1000);
				dic_pck.Add("clientTime", cl_tm);
			}
			
			// single => <string>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.SINGLE)) != (ulong)0)
			{
				dic_pck.Add("single", curUser.single);
			}
			
			// finishGuide => <int>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.FINISH_GUIDE)) != (ulong)0)
			{
				dic_pck.Add("finishGuide", curUser.finishGuide);
			}
			
			// soul => <int>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.SOUL)) != (ulong)0)
			{
				EplGenCmdArg arg = (EplGenCmdArg) o;
				if (arg == null)
				{
					DebugLog("错误地使用了命令参数[SOUL]");
					return;
				}
				dic_pck.Add("soul", arg.nSoul);
			}
			
			// isAMF => <int>
			if ((usr_cmd.CmdParam & ((ulong)1<<(int)CmdParam.IS_AMF)) != (ulong)0)
			{
				dic_pck.Add("isAMF", 1);
			}
			
			// 对命令进行封包
			List<byte> lst_byte = new List<byte>();
			// 0x11是 directory-marker，全部包都以此开头
			lst_byte.Add((byte)0x11);
			lst_byte.Add((byte)0x09);
			lst_byte.Add((byte)0x05);
			lst_byte.Add((byte)0x01);
			
			// 命令字打包
			byte[] bs_cmd_name = AMF_Serializer(usr_cmd.strCmdName);
			for (int i = 0; i < bs_cmd_name.Length; i++)
			{
				lst_byte.Add(bs_cmd_name[i]);
			}
			byte[] bs_dic = AMF_Serializer(dic_pck);
			for (int i = 0; i < bs_dic.Length; i++)
			{
				lst_byte.Add(bs_dic[i]);
			}
			string result = curUser.PageQuery(ServerParam.strGameSvr, "", lst_byte.ToArray(), Encoding.GetEncoding("iso-8859-1"));
			Print(Encoding.GetEncoding("iso-8859-1").GetBytes(result));
		}
		
		private void Print(byte[] bs)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < bs.Length; i++)
			{
				if ((bs[i] >= (byte) 'a' && bs[i] <= (byte) 'z')
				    || (bs[i] >= (byte) 'A' && bs[i] <= (byte) 'Z'))
				{
					sb.Append(Convert.ToChar(bs[i]).ToString() + " ");
				}
				else
				{
					if (i + 2 < bs.Length && 
					    bs[i] == 0x0A && bs[i + 1] == 0x0B)
					{
						sb.Append("\r\n");
					}
					sb.Append(bs[i].ToString("X2") + " ");
				}
			}
			WriteLog("cmd.txt", sb.ToString());
		}
		
		private string MakeSessionKey(User u)
		{
			return "{" 
				+ "\"act\":\"" + ServerParam.strAct + "\","
				+ "\"wyx_user_id\":\"" + u.wyx_user_id + "\","
				+ "\"wyx_session_key\":\"" + u.wyx_session_key + "\","
				+ "\"wyx_create\":\"" + u.wyx_create + "\","
				+ "\"wyx_expire\":\"" + u.wyx_expire + "\","
				+ "\"wyx_signature\":\"" + u.wyx_signature + "\","
				+ "\"serverId\":\"" + ServerParam.strServerID + "\""
				+ "}";
		}
		
		// 将对象转换为AMF格式的字节流
		public static byte[] AMF_Serializer(object obj)
		{
			ByteArray byteArray = new ByteArray();
			byteArray.WriteObject(obj);
			byte[] buffer = new byte[byteArray.Length];
			byteArray.Position = 0;
			byteArray.ReadBytes(buffer, 0, byteArray.Length);
			return buffer;
		}
		
		// 将AMF格式字节流转换为对象
		public static T AMF_Deserializer<T>(byte[] buffer, int length)
		{
			MemoryStream stream = new MemoryStream(buffer, 0, length);
			ByteArray byteArray = new ByteArray(stream);
			object obj = byteArray.ReadObject();
			if (obj == null)
			{
				return default(T);
			}
			return (T)obj;
		}
	}
	
	public class UserCommand
	{
		public string strCmdName;
		public ulong CmdParam;
		public UserCommand(string name, ulong p)
		{
			strCmdName = name;
			CmdParam = p;
		}
	}
	
	public class CmdArg
	{
		public CmdIDs cmd_id;
		public User cur_user;
		public CmdArg(CmdIDs id, User u)
		{
			this.cmd_id = id;
			this.cur_user = u;
		}
	}
	
	public class RfsGenCmdArg : CmdArg
	{
		public int nType;
		public RfsGenCmdArg(CmdIDs id, User u, int t) : base(id, u)
		{
			this.nType = t;
		}
	}
	
	public class EplGenCmdArg : CmdArg
	{
		public int nGenID;
		public int nSoul;
		public EplGenCmdArg(CmdIDs id, User u, int gen_id, int s) : base(id, u)
		{
			this.nGenID = gen_id;
			this.nSoul = s;
		}
	}
	
	public enum CmdIDs : int
	{
		NONE,
		USER_GET_INFO, // 获得角色的所有信息
		USER_GET_GIFT, // 获取礼物
		USER_GET_MESSAGE, // 获取系统消息
		FEED_MSG_BOX, // 获取广告消息
		USER_GET_LOGIN_AWARD, // 获取登陆奖励
		USER_GET_LUCK_INFO, // 获取幸运值
		USER_REFRESH_GENERAL, // 刷将魂
		USER_EMPLOY_GENERAL, // 获取将魂
	}
	
	public enum CmdParam : int
	{	
		TYPE, // 将魂刷新类型
		GENERAL_ID, // 武将ID
		CT, // 客户端的unix时间戳（毫秒数）
		VERSION, // 客户端版本号
		SESSION_KEY, // 会话信息
		CLIENT_TIME, // 客户端的unix时间戳（秒数）
		SINGLE, // 账号的唯一ID
		FINISH_GUIDE, // 新手指引的完成情况
		SOUL, // 将魂获取数量
		IS_AMF, // 是否为AMF包
		
		CMD_PARAM_END,
	}
}