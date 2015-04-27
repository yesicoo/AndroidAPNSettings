package me.xuqing;

import java.util.HashMap;
import java.util.Map;

public class Message {
	public String MsgComm;  //传过来的命令
	public String MsgCBComm;//回应的命令
	public Map<String,String> MsgDatas=new HashMap<String, String>();//数据
}
