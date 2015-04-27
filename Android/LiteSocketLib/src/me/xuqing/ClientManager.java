package me.xuqing;

import java.net.Socket;
import java.util.HashMap;
import java.util.Map;

public class ClientManager {
	static Integer ClientID=0;
	static Map<Integer, Client> Clients = new HashMap<>();

	public void AddClient(Socket socket) {
		Integer clientID= ClientID++;
		Client clinet = new Client(socket,clientID);
		new Thread(clinet).start();
		 Clients.put(clientID, clinet);
	}

	public void SendMsg(Integer clientID, String comm,
			Map<String, String> msgDatas) {
		if (Clients.containsKey(clientID)) {
			Client client = Clients.get(clientID);
			client.SendMsg(comm, msgDatas);
		}
	}
}
