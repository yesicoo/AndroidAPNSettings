package me.xuqing;

import java.util.HashMap;
import java.util.Map;

public class CommManager {

	static Map<String, CallBack> Comms = new HashMap<String, CallBack>();

	public static void Add(String comm, CallBack callBack) {
		Comms.put(comm, callBack);
	}

	public static CallBack Get(String comm) {
		if (Comms.containsKey(comm)) {
			CallBack callBack = Comms.get(comm);
			return callBack;
		} else {
			return null;
		}
	}
	
	public static void Remove(String comm) {
		Comms.remove(comm);
	}
}
