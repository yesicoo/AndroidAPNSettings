package me.xuqing;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Map;

public class SCServer implements Runnable {

	static Boolean Startd = false;
	static Integer Port;
	static ServerSocket serverSocket = null;
	ClientManager clientManager = new ClientManager();

	public SCServer(int port) {
		Port = port;
	}

	@Override
	public void run() {
		if (!Startd) {
			try {
				serverSocket = new ServerSocket(Port);
				Startd = true;
				System.out.println("Startd :" + Port);
			} catch (IOException e) {
				e.printStackTrace();
			}

			try {
				while (Startd) {
					Socket socket = serverSocket.accept();
					clientManager.AddClient(socket);
				}
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}

	public void RegistCallBack(String comm, CallBack callBack) {
		CommManager.Add(comm, callBack);
	}

	public void UnRegistCallBack(String comm) {
		CommManager.Remove(comm);
	}

	public void Send(Integer clientID, String comm, Map<String, String> msgDatas) {
		clientManager.SendMsg(clientID, comm, msgDatas);
	}

}
