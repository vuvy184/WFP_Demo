   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � 	Resources 5
   
    �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��
 ����6/   �� 5       � ��$ 5q�6+    5      P� 5       �@J�IsMouseOver$
 True��65   . �5      ��  � ��
 ��ح�67   5      5      5      .+�5   
   �� -   5         ��Name$ Label��5      $��Nhập thông tin��6   $��
112,58,0,0q�68   $
��Bold"�6L   $
��Left=�6^   $	��103��6y   $��31��6�   $	��Top=�6�   �� 5   
   -   5        	 ��Name$	 inputTextBox��5      $��228,58,306,0q�6(   
 �� TextWrapping$

 Wrap=�6>   ���	#FF77B3FF$��31��6j   $	��Top=�6v   �� 5   
   -   5         ��Name$ 	addButton��5      $	��Add��6$   $��
0,58,220,0q�62    J� RenderTransformOrigin$ 0.494,0.625&�6F   $��Right=�6�   $��60��6�   $��30��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ listView��5      $��141,160,141,144q�6%   ���	#FF1060F1#��� ��6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6   �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��6U    �� DisplayMemberBinding 61   �� *ID+6U   �� 5      $��Content��6%   $	 200��6_    66   �� *	Content+6_   �� 5      $��Action��6%   $	 150��65    �� CellTemplate 5      �� 5      .R�5    "   ��  �� Orientation$ 
Horizontal=�6-   .+�5!   &   �� -   5        $��Delete��5!   -   $��40��6l   
 � Tag 6Y   �� *ID+6l   �� 5"   &   -   5        $
��Edit��5"   -   $��40��6h    6U   �� *ID+6h   5#   #   5$      5&      5'      5)      �� 5*   
   -   5        $ Close��5*      $��Close��6    $��
230,0,0,48q�60   $��40��6X   $��Bottom=�6d   $
��Left=�6   $��80��6�   �� 5+   
   -   5        $
 save��5+      $
��Save��6   $��
0,0,271,46q�6.   $��Right=�6U   $��80��6q   $��40��6|   $��Bottom=�6�   5,      5-      