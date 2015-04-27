package me.xuqing;

import java.util.Map;

public interface CallBack {
	 public void execute(Integer clientID, String callBackComm,
				Map<String, String> msgDatas);  
}
