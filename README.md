<html>
<head>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" />
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<style>
	 hr{
		border-bottom: solid #bbb 1px;
	 }
	 p{
		text-align: justify;
		text-indent: 30px;
	 }
	 img{
		margin-left: 30px;
		margin-bottom: 15px;
		width: 500px;
		height: auto;
	 }
	 .note{
		font-size: 0.8em;
		font-style: italic;
		font-weight: 800;
	 }
	</style>
</head>
<body>
	<div class="container">		
		<div class="row">
			<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
				<div style="text-align: center">
					<h3>Nostalgic Play</h3>
				</div>
				<p>
				Nostalgic Play was made to make easier to manage games emulators into your computer. We know there are a lot
				of emulators managers already done, but all We've known before were kind of anoying for setting and use it. For kids then, they were a terrible expierence. Then, thinking in all those momys and dads who had to change game every time for their kids, it became an ideia to create this windows app who is able to manage emulators and roms in an easy way. So, now, kids may play without any help from their parents using a simple emulators manager.
				</p>
			</div>
		</div>
		<hr>
		<div class="row">
			<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
				<h4>Requirements</h4>
				<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
					Check requirements for running Nostalgic Play:
					<ol>
						<li>Windows System</li>
						<li>.Net Framework: 2.0, 3.5 and 4.6</li>
						<li>Emulators listed bellow you would like to play</li>
						<li>Roms directory created into your emulator path</li>
						<li>USB Joystick plugged into your computer.</li>
					</ol>
				</div>
			</div>
		</div>
		<hr>
		<div class="row">
			<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
				<h4>Implemented Emulators</h4>
				<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
					Nostalgic Play is nowaday able to work with three emulators:
					<ol>
						<li>Fusion - Mega Drive</li>
						<li>Snes9x - Super NES</li>
						<li>Project64 - Nintendo 64</li>
					</ol>
				</div>
			</div>
		</div>
		<hr>
		<div class="row">
			<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
				<h4>Install</h4>
				<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
					<p>
						With all your emulators already installed, start downloading Nostalgic Play, then extract it for the directory you would like to keep it:						
					</p>
					![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/001.png)
					<p>
						After that, open Nostalgic Play directory and edit NostalgicPlay.exe.config file with your prefered notepad app, in this example we're using notepad++. In the AppSettings tags, there are a few configurations you'll have to set:
						<ol>
							<li>MegaDrivePath => In the value, you are supposed to set the Fusion path.</li>
							<li>SuperNintendoPath => In the value, you are supposed to set the SNes9x path.</li>
							<li>Nintendo64Path => In the value, you are supposed to set the Project64 path.</li>
							<li>DefaultRomImage => An Image path to be the default image to be showned when rom has no image. Chose an image, this setting is required.</li>
						</ol>
					</p>
					<div class="note">Note: the paths setted in the configuration file should have the emulator .exe</div>
					Bellow, you may see a configuration file example and emulator path example: 
					<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
						<div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
							![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/002.png)
						</div>
						<div class="col-md-6">
							![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/003.png)
						</div>
					</div>
					<div class="clearfix" />
					<div class="note">Note: Pay attention for the Roms directory inside the MegaDrivePath.</div>
					<div class="note">Note: If you do not want to set all emulators implemented, just let the value property empty in the configuration file, then, go to NostalgiPlayDirectory/Resource and delete emulator image into this page.</div>
					<br>
					<p>
						To help kids select the game, you may setup an image for showing selected game. To do it, all you've gotta do is run into Roms directory and save the image you want to be showned with same name the game file, as bellow:
					</p>
					![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/004.png)
					<div class="note">Note: Is you do not set this image, the default image will be displayed, then, it makes a default image required.</div>
					<br>
					<p>
						With all those settings ready, is time to open Nostalgic Play. The first time you'll have to set your control:
						<ol>
							<li>Up</li>
							<li>Left</li>
							<li>Down</li>
							<li>Right</li>
							<li>Confirm Button => Button used to confirm emulator selected and in the roms screen to open game.</li>
							<li>Esc Button => Bustton use to quit roms screen and go back to game selection</li>
							<li>Close Button 1 => Pressed combined with Close Button 2 will close game oppened.</li>
							<li>Close Button 2 => Pressed combined with Close Button 1 will close game oppened.</li>
						</ol>
						See bellow the application in use:<br>
						![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/005.png)
						<br>
						![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/006.png)
						<br>
						![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/007.png)
						<br>
						![image](https://github.com/dynagita/NostalgicPlay/tree/master/NostalgicPlay/Images/008.png)
					</p>
				</div>
			</div>
		</div>
	</div>
</body>
</html>
