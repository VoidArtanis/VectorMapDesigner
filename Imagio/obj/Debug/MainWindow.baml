   M S B A M L   `   `   `  ����A  =Imagio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ImagioImagio  5   	   9!clr-namespace:Imagio.GUI.ControlsImagio.GUI.Controls  5   	       Imagio.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Imagio     5   	   6controls!clr-namespace:Imagio.GUI.Controls     5   	     � Title$  
MainWindow��5	   	   $	��614��6   $	��921��6)   .��5      � .+�5   
   )   #Imagio.GUI.Controls.DraggableCanvas  -   5          Name$ 	MapCanvas��5   #   )   #Imagio.GUI.Controls.DraggableCanvas   PreviewMouseLeftButtonUp$( "MapCanvas_PreviewMouseLeftButtonUp��5   :      PreviewMouseMove$  MapCanvas_PreviewMouseMove��5   #      AllowDragOutOfView . $��	154,0,0,0q�5   P   ���	#FFEEEEEE5   #   �� 5   
   -   5         ��Name$ s_Copy��5      $��Filter��6!   $��26��6H   $	��Top=�6T   $
��Left=�5      $��42��6,   $��47,0,0,0q�67   d� 5   
   -   5         d�Name$
 mtog��5      $��Manual��6%   $
��Left=�66   $��0,31,0,0q�6Q   $	��Top=�5      $��89��6/   �� 5   
   -   5        $ s_Copy1��5      $
��Draw��6"   $��26��6G   $	��Top=�6S   $
��Left=�5      $��89��6,   d� 5   
   -   5        $ mSpace��5      $��	Space Out��6'   $
��Left=�6;   $��0,56,0,0q�6V   $	��Top=�5      $��89��6/   �� 5   
   -   5        $ s_Copy2��5      $��Filter��6"   $��26��6A   $	��Top=�6M   $
��Left=�5      $��89��6,   $��0,81,0,0q�67   �� 5   
   -   5        $ douglasPeucker��5      $��DouglasPeucker��6)   $��26��6B   $	��Top=�6N   $
��Left=�5      $��89��6,   $��	0,112,0,0q�67   6J   �� 5   
   -   5        $ 
btnConnect��5      $��Connect��6%   $��26��67   $	��Top=�6C   $
��Left=�6[   $��89��5      $��	0,143,0,0q�6   6/   �� 5   
   -	   5        $ douglasPeucker_Copy��5      $��DP box��6.   $��26��6?   $	��Top=�6K   $
��Left=�5      $��89��6,   $��	0,174,0,0q�67   6J   �� 5   
   -
   5        $ douglasPeucker_Copy1��5      $��Graph��6/   $��26��6?   $	��Top=�6K   $
��Left=�5       $��89��6,   $��	0,216,0,0q�67   6J   5"      5#      