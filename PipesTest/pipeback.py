import sys
import getpass
import time




def main(args,**kwargs):
    reqiredarg = ""
    TESTFREQUENCY_HZ = 60
    close = False
    counter = 0
    # Define for Types: 0=Int, 1=Float, 3 = Char, 4 = Double, 5 = Long
    
    # Message Format = Name,Type,Data$ 
    #Example "TestVariable,0,10$Test2Variable,1,10.23123$"
    

    for key in args[1:]:
        arg,value = key.split("=")
        if arg == "framerate":
            TESTFREQUENCY_HZ = int(value)
    
    while not close:
        sys.stdout.flush()
        counter+=1
        recaived_message = sys.stdin.readline().rstrip()
        if recaived_message == "GIMME MESSAGE BIATCH":
            print("Received: "+recaived_message+", Here are the Test Values:",counter)
        time.sleep(1.0 / TESTFREQUENCY_HZ)
    
if __name__ == "__main__":
    main(sys.argv)