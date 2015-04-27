package me.xuqing;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.Socket;
import java.util.Map;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;

public class Client implements Runnable {
	private Socket socket;
	private DataOutputStream dos = null;
	private BufferedReader brIs = null;
	private boolean bConnected = false;
	public Integer ClientID = -1;

	public Client(Socket socket, int id) {
		this.socket = socket;
		this.ClientID = id;
	}

	@SuppressWarnings("unchecked")
	@Override
	public void run() {
		try {
			brIs = new BufferedReader(new InputStreamReader(
					socket.getInputStream(), "UTF-8"));
			dos = new DataOutputStream(socket.getOutputStream());
			System.out.println(this.ClientID + " Start");
			bConnected = true;
			while (bConnected) {
				String str = brIs.readLine();
				if(str!=null){
				System.out.println("-------->" + str);
				JSONObject jb = JSON.parseObject(str);
				String msgComm = jb.getString("MsgComm");
				CallBack cb = CommManager.Get(msgComm);
				if (cb != null) {
					String msgCBComm = jb.getString("MsgCBComm");
					Map<String, String> msgDatas = (Map<String, String>) JSON.parse(jb.getString("MsgDatas"));
					cb.execute(ClientID, msgCBComm, msgDatas);
				} else {
					System.out.println("--->MsgComm:[" + msgComm+ "] Can't Find!");
				}}
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	public void SendMsg(String comm, String callBackComm,
			Map<String, String> msgDatas) {
		Message msg = new Message();
		msg.MsgCBComm = callBackComm;
		msg.MsgComm = comm;
		msg.MsgDatas = msgDatas;
		String StrJson = JSON.toJSONString(msg);
		System.out.println("<--------"+StrJson);
		try {
			this.dos.writeUTF(StrJson);
			this.dos.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	public void SendMsg(String comm, Map<String, String> msgDatas) {
		SendMsg(comm,"",msgDatas);
	}
}
