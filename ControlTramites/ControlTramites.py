import wpf 
from System.Windows import Application, Window

import pandas as pd

class MyWindow(Window):
    def __init__(self):
        wpf.LoadComponent(self, 'ControlTramites.xaml')
    

if __name__ == '__main__':
    Application().Run(MyWindow())
