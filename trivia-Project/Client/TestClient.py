import socket
import json

SERVER_IP = "127.0.0.1"
SERVER_PORT = 1333

def main():
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_address = (SERVER_IP, SERVER_PORT)
    sock.connect(server_address)
    signupMsg = '2' + '0069' + '{\"username\":\"Shahar\", \"password\":546545, \"email\":"NewYork@gamil.com"}'
    loginMsg = '1' + '0037' + '{"username":"Avi", "password":306080}'
    loginMsg1 = '1' + '0040' + '{"username":"SHAHAR", "password":546545}'
    
    server_msg = sock.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    if(server_msg == "Hello"):
        msg = "hello"
        sock.sendall(msg.encode())
    print("\nsignup first time\n")    
    sock.sendall(signupMsg.encode())
    server_msg = sock.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    
    
    sock1 = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock1.connect(server_address)
    server_msg = sock1.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    if(server_msg == "Hello"):
        msg = "hello"
        sock1.sendall(msg.encode())
    print("\nlogin first time\n")    
    sock1.sendall(loginMsg.encode())
    server_msg = sock1.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    
    sock2 = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock2.connect(server_address)
    server_msg = sock2.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    if(server_msg == "Hello"):
        msg = "hello"
        sock2.sendall(msg.encode())
    print("\nlogin with the same user\n")    
    sock2.sendall(loginMsg.encode())
    server_msg = sock2.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    
    sock3 = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock3.connect(server_address)
    server_msg = sock3.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    if(server_msg == "Hello"):
        msg = "hello"
        sock3.sendall(msg.encode())
    print("\nlogin with user that not exist\n")    
    sock3.sendall(loginMsg1.encode())
    server_msg = sock3.recv(1024)
    server_msg = server_msg.decode()
    print(server_msg)
    
if __name__ == '__main__':
    main()
